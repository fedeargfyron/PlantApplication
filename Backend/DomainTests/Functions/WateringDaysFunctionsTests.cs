using Domain.Entities;
using Domain.Functions;

namespace DomainTests.Functions;

public class WateringDaysFunctionsTests
{
    [Fact]
    public void ConvertWithSingleDay_WhenPasswordDoesntMatch_ReturnsNotEqualPassword()
    {
        // Arrange
        var initialDate = DateTime.Today;
        var maximumCalculatedDate = initialDate.AddDays(10);
        const string wateringDaysFrequency = "2";
        var expected = new List<DateTime>
        {
            initialDate,
            initialDate.AddDays(2),
            initialDate.AddDays(4),
            initialDate.AddDays(6),
            initialDate.AddDays(8),
        };

        // Act
        var result = WateringDaysFunctions.ConvertWithSingleDay(wateringDaysFrequency, initialDate, maximumCalculatedDate);
        var actual = result.Select(x => x.Day).ToList();

        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void ConvertWithSingleDay_WhenPasswordMatch_ReturnsEqualPassword()
    {
        // Arrange
        var maximumCalculatedDate = DateTime.Today;
        var initialDate = maximumCalculatedDate.AddDays(-2);
        const string wateringDaysFrequency = "2";
        var expected = new List<DateTime>();

        // Act
        var result = WateringDaysFunctions.ConvertWithSingleDay(wateringDaysFrequency, initialDate, maximumCalculatedDate);
        var actual = result.Select(x => x.Day).ToList();

        // Assert
        Assert.Equivalent(expected, actual);
    }
}
