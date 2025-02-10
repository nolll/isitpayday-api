using Core.UseCases;

namespace Api.Plumbing;

public class UseCaseContainer
{
    public MonthlyPayday MonthlyPayday => new();
    public WeeklyPayday WeeklyPayday => new();
    public Options Options => new();
}