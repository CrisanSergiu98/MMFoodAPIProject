CREATE TABLE [dbo].[RecipeIngredient]
(	    
    [RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL, 
    [Quantity] FLOAT NOT NULL, 
    [Unit] NVARCHAR(50) NOT NULL
)
