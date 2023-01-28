namespace FurniturePartsTests;

public class UnitTests
{
    [Fact]
    public void PartShouldHaveSameCodeAcrossTwoProducts()
    {
        // Arrange
        IProductFactory products = ProductFactory.Construct(storageStrategy: StorageStrategy.InMemory); // in-memory used for development testing only
        Product productOne = products.Create(name: "Product One");
        Product productTwo = products.Create(name: "Product Two");

        IPartsFactory parts = PartsFactory.Construct(storageStrategy: StorageStrategy.InMemory);
        Part testPart = parts.Create(name: "Test Part", products: productOne, productTwo);
        productOne.AddPart(testPart);
        productTwo.AddPart(testPart);

        // Act
        PartId partIdFromProduct1 = productOne.GetPart(name: "Test Part").Id;
        PartId partIdFromProduct2 = productTwo.GetPart(name: "Test Part").Id;

        // Assert
        Assert.NotEqual(partIdFromProduct1, partIdFromProduct2);
    }

    [Fact]
    public void PartCodeShouldOnlyBeAlphanumeric()
    {
        // Arrange
        IPartsFactory parts = PartsFactory.Construct(storageStrategy: StorageStrategy.InMemory);
        Part part = parts.Create(name: "Test Part");

        // Act
        PartId sut = part.Id;

        // Assert
        Assert.Matches("[A-Za-z0-9]+", sut.ToString());
    }

    [Fact]
    public void PartCodeDoesNotExceedFiveCharacters()
    {
        // Arrange
        IPartsFactory parts = PartsFactory.Construct(storageStrategy: StorageStrategy.InMemory);
        Part part = parts.Create(name: "Test Part");

        // Act
        PartId sut = part.Id;

        // Assert
        Assert.True(sut.ToString().Length == 5);
    }

    [Fact]
    public void PartCodeIsSuffixedWithLastTwoCharsOfParentProduct()
    {
        // Arrange
        IProductFactory products = ProductFactory.Construct(storageStrategy: StorageStrategy.InMemory); // in-memory used for development testing only
        Product productOne = products.Create(name: "Product One");

        IPartsFactory parts = PartsFactory.Construct(storageStrategy: StorageStrategy.InMemory);
        Part part = parts.Create(name: "Test Part");

        productOne.AddPart(part);

        ProductId productId = productOne.Id;

        // Act
        PartId sut = part.Id;

        // Assert
        Assert.EndsWith(productId.ToString()[^2..], part.Id);
    }

    [Fact]
    public void PartCodePrefixedWithDisownmentCodeIfNoParentProduct()
    {
        // Arrange
        IPartsFactory parts = PartsFactory.Construct(storageStrategy: StorageStrategy.InMemory);
        Part part = parts.Create(name: "Test Part");
        IPartRuleset ruleset = parts.Rules;

        // Act
        PartId sut = part.Id;

        // Assert
        Assert.StartsWith(ruleset.DisownmentCode, sut.ToString());
    }
}