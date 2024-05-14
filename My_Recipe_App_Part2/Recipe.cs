using System;
using System.Collections.Generic;

// Recipe class representing a recipe
public class Recipe
{
    // Private fields to hold ingredients and steps
    private List<Ingredient> ingredients;
    private List<RecipeStep> steps;

    // Constructor to initialize recipe with a name
    public Recipe(string name)
    {
        Name = name;
        ingredients = new List<Ingredient>();
        steps = new List<RecipeStep>();
    }

    // Public property for the name of the recipe
    public string Name { get; private set; }

    // Method to add an ingredient to the recipe
    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    // Method to add a step to the recipe
    public void AddStep(RecipeStep step)
    {
        steps.Add(step);
    }

    // Method to calculate the total calories of the recipe
    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        foreach (var ingredient in ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe:");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i].Description}");
        }
    }

    // Delegate for notifying when total calories exceed 300
    public delegate void NotifyExceedCaloriesHandler();

    // Event for notifying when total calories exceed 300
    public event NotifyExceedCaloriesHandler ExceedCaloriesEvent;

    // Method to check if total calories exceed 300 and raise event if so
    public void CheckTotalCalories()
    {
        if (CalculateTotalCalories() > 300)
        {
            ExceedCaloriesEvent?.Invoke();
        }
    }
}
