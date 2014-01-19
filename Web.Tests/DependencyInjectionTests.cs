using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;
using Web.Models;
using Web.Plumbing;

namespace Web.Tests
{
    [TestFixture]
    public class DependencyInjectionTests
    {
        private readonly IList<Type> _ignoredInterfaces;

        public DependencyInjectionTests()
        {
            // Interface som inte är injicerade och som inte ska injiceras
            _ignoredInterfaces = new List<Type>
                {
                    typeof(IPageModel),
                };
        }

        [Test]
        public void Resolve_ApplicableInterfacesCanBeResolved()
        {
            var webAssembly = Assembly.GetAssembly(typeof(WebObjectFactory));

            var windsorContainer = new WindsorContainer()
                .Install(FromAssembly.Instance(webAssembly));
            var objectFactory = new WebObjectFactory(windsorContainer, LifestyleType.Transient);
            VerifyInterfaceResolve(objectFactory, webAssembly, _ignoredInterfaces);
        }

        private static void VerifyInterfaceResolve(ObjectFactory objectFactory, Assembly assembly, IList<Type> ignoredInterfaces)
        {
            var interfaces = assembly.GetTypes().Where(x => x.IsInterface);
            foreach (var i in interfaces)
            {
                if (!ignoredInterfaces.Contains(i))
                {
                    objectFactory.ResolveOrThrow(i);
                }
            }
        }
    }
}