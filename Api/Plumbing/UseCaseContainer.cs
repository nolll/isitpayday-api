using Core.UseCases;

namespace Api.Plumbing;

public class UseCaseContainer
{
    public MonthlyPayday MonthlyPayday => new MonthlyPayday();
    public WeeklyPayday WeeklyPayday => new WeeklyPayday();
    public Options Options => new Options();
}