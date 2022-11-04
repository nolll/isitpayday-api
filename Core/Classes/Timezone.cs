using System;

namespace Core.Classes;

public class Timezone
{
    public string Id { get; }
    public string Name { get; }
    public TimeZoneInfo SystemTimeZone => TimeZoneInfo.FindSystemTimeZoneById(Id);

    public Timezone(string id, string name)
    {
        Id = id;
        Name = name;
    }
}