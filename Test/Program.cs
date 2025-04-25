using Xunit;
using TaskManagementApp.Services;

public class CountNumberServiceTests
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(2, 3);

        // Assert
        Assert.Equal(5, result);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    [InlineData(-1, 4, -4)]
    public void Multiply_ReturnsCorrectProduct(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}
