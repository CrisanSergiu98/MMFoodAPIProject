CREATE TABLE [dbo].[RecipeIngredient]
(	
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL, 
    [QuantityId] INT NOT NULL, 
    [UnitId] INT NOT NULL, 
    CONSTRAINT [FK_RecipeIngredient_ToRecipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id), 
    CONSTRAINT [FK_RecipeIngredient_ToIngredient] FOREIGN KEY (IngredientId) REFERENCES Ingredient(Id), 
    CONSTRAINT [FK_RecipeIngredient_ToQuantity] FOREIGN KEY (QuantityId) REFERENCES Quantity(Id), 
    CONSTRAINT [FK_RecipeIngredient_To] FOREIGN KEY (UnitId) REFERENCES Unit(Id)
)
