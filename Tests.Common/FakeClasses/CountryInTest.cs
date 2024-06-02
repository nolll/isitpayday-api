using Core.Classes;

namespace Tests.Common.FakeClasses;

public record CountryInTest(
    string Id = "",
    string CultureName = "",
    string Name = "")
    : Country(
        Id,
        CultureName,
        Name);