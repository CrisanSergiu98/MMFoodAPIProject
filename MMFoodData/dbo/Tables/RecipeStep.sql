CREATE TABLE [dbo].[RecipeStep]
(
    [RecipeId] INT NOT NULL, 
    [Number] INT NOT NULL,
    [Title] NVARCHAR(50) NOT NULL, 
    [Details] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_RecipeStep_ToRecipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
)
