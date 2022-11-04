using JetBrains.Annotations;

namespace Api.Models;

public class CountryModel
{
    [UsedImplicitly]
    public string Id { get; }

    [UsedImplicitly]
    public string Name { get; }

    public CountryModel(string id, string name)
    {
        Id = id;
        Name = name;
    }
}