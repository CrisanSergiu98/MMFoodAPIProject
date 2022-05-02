CREATE TABLE [dbo].[IngredientCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [PictureUrl] NVARCHAR(MAX) NULL 
)
