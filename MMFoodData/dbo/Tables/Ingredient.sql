CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [Description] NCHAR(10) NOT NULL, 
    [PuctureURL] NCHAR(10) NULL, 
    CONSTRAINT [FK_Ingredient_ToIngredientCategory] FOREIGN KEY ([CategoryId]) REFERENCES IngredientCategory(Id)
)
