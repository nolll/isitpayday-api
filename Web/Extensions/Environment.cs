namespace Web.Extensions
{
    public static class Environment
    {
        public static bool IsProd(string hostName)
        {
            return hostName.EndsWith("isitpayday.com");
        }
    }
}