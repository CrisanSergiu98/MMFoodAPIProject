CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [PictureUrl] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Ingredient_ToIngredientCategory] FOREIGN KEY ([CategoryId]) REFERENCES IngredientCategory(Id)
)
