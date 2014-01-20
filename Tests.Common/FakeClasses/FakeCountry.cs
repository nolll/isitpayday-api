using Core.Classes;

namespace Tests.Common.FakeClasses
{
    public class FakeCountry : Country
    {
        public FakeCountry(
            string id = default(string), 
            string name = default(string)) : 
            base(
            id, 
            name)
        {
        }
    }
}
