using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
[TestFixture]
public class RecipeTests
{
    [Test]
    public void CalculateTotalCalories_ReturnsCorrectTotalCalories()
    {
        // Arrange
        var recipe = new Recipe("Test Recipe");
        recipe.AddIngredient(new Ingredient { Name = "Ingredient 1", Quantity = 100, Unit = "g", Calories = 50, FoodGroup = "Test Group 1" });
        recipe.AddIngredient(new Ingredient { Name = "Ingredient 2", Quantity = 200, Unit = "g", Calories = 100, FoodGroup = "Test Group 2" });
        recipe.AddIngredient(new Ingredient { Name = "Ingredient 3", Quantity = 150, Unit = "g", Calories = 75, FoodGroup = "Test Group 3" });

        // Act
        var totalCalories = recipe.CalculateTotalCalories();

        // Assert
        Assert.AreEqual(225, totalCalories);
    }
}
