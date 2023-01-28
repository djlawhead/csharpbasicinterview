namespace MysteriousNumbersTests;

public class UnitTest1
{
    [Theory]
    [InlineData(9, new[] { 2, 7, 11, 15 })]
    [InlineData(6, new[] { 3, 2, 4 })]
    [InlineData(6, new[] { 3, 3, 3, 3 })]
    [InlineData(2, new[] { 1, 8, 3, 3, 5, 1 })]
    [InlineData(1000, new int[0])]
    [InlineData(-10, null)]
    public void TwoNumbersCreateExpectedSum(int target, int[] numbers)
    {
        // Arrange
        var sut = new TwoSum();

        // Act
        var result = sut.TwoSum(target, numbers);

        // Assert
        Assert.Equal(target, result);
    }
}