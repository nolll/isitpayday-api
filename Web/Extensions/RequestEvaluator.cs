﻿using System.Web;

namespace Web.Extensions
{
    public static class RequestEvaluator
    {
        public static bool IsTestEnvironment(HttpRequestBase request)
        {
            return IsTestEnvironment(GetHostName(request));
        }

        private static bool IsTestEnvironment(string hostName)
        {
            return Environment.IsDev(hostName) || Environment.IsTest(hostName) || Environment.IsStage(hostName);
        }

        private static string GetHostName(HttpRequestBase request)
        {
            return request.Url?.Host ?? string.Empty;
        }
    }
}