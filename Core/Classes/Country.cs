namespace Core.Classes
{
    public class Country
    {
        public string Id { get; }
        public string Name { get; }

        public Country(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}