CREATE TABLE [dbo].[RecipeCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    [Description] NCHAR(10) NOT NULL, 
    [PictureURL] NCHAR(10) NOT NULL
)
