CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    [IngredientCategoryId] INT NOT NULL, 
    [Description] NCHAR(10) NOT NULL, 
    [PuctureURL] NCHAR(10) NULL
)
