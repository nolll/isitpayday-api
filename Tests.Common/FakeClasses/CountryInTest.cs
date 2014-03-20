using Core.Classes;

namespace Tests.Common.FakeClasses
{
    public class CountryInTest : Country
    {
        public CountryInTest(
            string id = default(string), 
            string name = default(string)) : 
            base(
            id, 
            name)
        {
        }
    }
}
