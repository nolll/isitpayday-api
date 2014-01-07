﻿using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Web.Plumbing
{
    public abstract class ObjectFactory : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly LifestyleType _lifestyleType;

        protected ObjectFactory(IWindsorContainer container, LifestyleType lifestyleType = LifestyleType.PerWebRequest)
        {
            _container = container;
            _lifestyleType = lifestyleType;
        }

        protected void RegisterComponent<T, TK>()
            where TK : class
            where T : class
        {
            RegisterComponent<T, TK>(_lifestyleType);
        }

        public void RegisterComponent<T, TK>(LifestyleType lifestyleType)
            where TK : class
            where T : class
        {
            _container.Register(Component.For<T, TK>().LifeStyle.Is(lifestyleType));
        }

        public void ResolveOrThrow(Type t)
        {
            _container.Resolve(t);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}