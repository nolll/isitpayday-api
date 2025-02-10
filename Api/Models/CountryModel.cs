using JetBrains.Annotations;

namespace Api.Models;

public class CountryModel(string id, string name)
{
    [UsedImplicitly]
    public string Id { get; } = id;

    [UsedImplicitly]
    public string Name { get; } = name;
}