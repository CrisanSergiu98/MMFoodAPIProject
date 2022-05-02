CREATE TABLE [dbo].[RecipeIngredient]
(	    
    [RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL, 
    [Quantity] FLOAT NOT NULL, 
    [Unit] NVARCHAR(50) NOT NULL, 
    [IsRequired] BIT NULL, 
    CONSTRAINT [FK_RecipeIngredient_ToRecipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id), 
    CONSTRAINT [FK_RecipeIngredient_ToIngredient] FOREIGN KEY (IngredientId) REFERENCES Ingredient(Id)
)
