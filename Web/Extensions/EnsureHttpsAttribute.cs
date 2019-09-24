﻿using System;
using System.Web.Mvc;

namespace Web.Extensions
{
    public class EnsureHttpsAttribute : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));

            if (filterContext.HttpContext != null && RequestEvaluator.IsTestEnvironment(filterContext.HttpContext.Request))
                return;

            base.OnAuthorization(filterContext);
        }
    }
}