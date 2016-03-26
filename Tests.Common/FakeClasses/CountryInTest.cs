using Core.Classes;

namespace Tests.Common.FakeClasses
{
    public class CountryInTest : Country
    {
        public CountryInTest(
            string id = "", 
            string name = "") : 
            base(
            id, 
            name)
        {
        }
    }
}
