using NUnit.Framework;

namespace Core.Tests.DateEvaluators.HolidayEvaluators;

public class GivenDefaultCountry : Arrange
{
    [Test]
    public void NewYearsDayIsNotHoliday() => Assert.That(IsHoliday("2016-01-01"), Is.False);

    [Test]
    public void EpiphanyIsNotHoliday() => Assert.That(IsHoliday("2016-01-06"), Is.False);

    [Test]
    public void GoodFridayIsNotHoliday() => Assert.That(IsHoliday("2016-03-25"), Is.False);

    [Test]
    public void EasterMondayIsNotHoliday() => Assert.That(IsHoliday("2016-03-28"), Is.False);

    [Test]
    public void AscensionDayIsNotHoliday() => Assert.That(IsHoliday("2016-05-05"), Is.False);

    [Test]
    public void ChristmasEveIsNotHoliday() => Assert.That(IsHoliday("2016-12-24"), Is.False);

    [Test]
    public void ChristmasDayIsNotHoliday() => Assert.That(IsHoliday("2016-12-25"), Is.False);

    [Test]
    public void BoxingDayIsNotHoliday() => Assert.That(IsHoliday("2016-12-26"), Is.False);

    [Test]
    public void NewYearsEveIsNotHoliday() => Assert.That(IsHoliday("2016-12-31"), Is.False);

    [Test]
    public void AnyOtherDayIsNotHoliday() => Assert.That(IsHoliday("2016-01-02"), Is.False);
}