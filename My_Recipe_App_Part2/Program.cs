using System;
using System.Collections.Generic;

// Program class representing the entry point of the Salad Recipe App
public class Program
{
    // Main method: Entry point of the application
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Salad Recipe App!");

        // List to store recipes
        List<Recipe> recipes = new List<Recipe>();

        while (true)
        {
            Console.Write("Choose an option: ");
            Console.WriteLine("\n1. Add Recipe");
            Console.WriteLine("2. Display Recipes");
            Console.WriteLine("3. Exit");

            // Read user choice
            string choice = Console.ReadLine();

            // Switch based on user choice
            switch (choice)
            {
                case "1":
                    Recipe newRecipe = CreateRecipe();
                    recipes.Add(newRecipe);
                    break;
                case "2":
                    DisplayRecipes(recipes);
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to create a new recipe
    static Recipe CreateRecipe()
    {
        Console.Write("Enter recipe name: ");
        string name = Console.ReadLine();

        Recipe recipe = new Recipe(name); // Pass the recipe name as a parameter

        Console.Write("Enter the number of ingredients: ");
        int numIngredients = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write($"Enter name of ingredient {i + 1}: ");
            string ingredientName = Console.ReadLine();
            Console.Write($"Enter quantity of {ingredientName}: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter unit of measurement for {ingredientName}: ");
            string unit = Console.ReadLine();
            Console.Write($"Enter calories for {ingredientName}: ");
            double calories = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter food group for {ingredientName}: ");
            string foodGroup = Console.ReadLine();

            recipe.AddIngredient(new Ingredient { Name = ingredientName, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
        }

        Console.Write("Enter the number of steps: ");
        int numSteps = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter description for step {i + 1}: ");
            string description = Console.ReadLine();

            recipe.AddStep(new RecipeStep { Description = description });
        }

        // Subscribe to ExceedCaloriesEvent
        recipe.ExceedCaloriesEvent += () =>
        {
            Console.WriteLine("Warning: Total calories exceed 300!");
        };

        return recipe;
    }

    // Method to display recipes
    static void DisplayRecipes(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes to display.");
            return;
        }

        Console.WriteLine("\nRecipes:");
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name);
        }

        Console.Write("Enter the name of the recipe you want to display or delete: ");
        string recipeName = Console.ReadLine();
        Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
        if (selectedRecipe != null)
        {
            selectedRecipe.DisplayRecipe();
            Console.WriteLine("\nDo you want to delete this recipe? (yes/no)");
            string deleteChoice = Console.ReadLine();
            if (deleteChoice.ToLower() == "yes")
            {
                recipes.Remove(selectedRecipe);
                Console.WriteLine("Recipe deleted successfully.");
            }
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
}
