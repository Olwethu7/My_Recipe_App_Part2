using System;

// Ingredient class representing an ingredient with name, quantity, calories, and food group
public class Ingredient
{
    // Properties encapsulating ingredient details

 
    /// Gets or sets the name of the ingredient.
    public string Name { get; set; }

    /// Gets or sets the quantity of the ingredient.
    public double Quantity { get; set; }

    /// Gets or sets the unit of measurement for the ingredient.
    public string Unit { get; set; }

    
    ///Gets or sets the calories of the ingredient.
    public double Calories { get; set; }

    /// Gets or sets the food group of the ingredient.
    public string FoodGroup { get; set; }
}
