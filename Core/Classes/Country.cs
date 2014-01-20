namespace Core.Classes
{
    public class Country
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Country(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}