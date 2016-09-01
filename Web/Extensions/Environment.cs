namespace Web.Extensions
{
    public static class Environment
    {
        public static bool IsProd(string hostName)
        {
            return hostName.EndsWith("isitpayday.com");
        }

        public static bool IsDev(string hostName)
        {
            return hostName.EndsWith("isitpayday.lan");
        }

        public static bool IsTest(string hostName)
        {
            return hostName.EndsWith("homeip.net");
        }

        public static bool IsStage(string hostName)
        {
            return hostName.EndsWith("staging.isitpayday.com");
        }
    }
}