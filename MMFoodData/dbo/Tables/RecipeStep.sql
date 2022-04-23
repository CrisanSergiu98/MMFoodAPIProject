CREATE TABLE [dbo].[RecipeStep]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [RecipeId] NCHAR(10) NOT NULL, 
    [Number] INT NOT NULL,
    [Title] NCHAR(10) NOT NULL, 
    [Details] NCHAR(10) NOT NULL, 
    [PictureURL] NCHAR(10) NOT NULL
)
