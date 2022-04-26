CREATE TABLE [dbo].[RecipeStep]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [RecipeId] INT NOT NULL, 
    [Number] INT NOT NULL,
    [Title] NCHAR(10) NOT NULL, 
    [Details] NCHAR(10) NOT NULL, 
    [PictureURL] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_RecipeStep_ToRecipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
)
