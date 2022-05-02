CREATE TABLE [dbo].[Business]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(50) NULL, 
    [ProfilePictureURL] NVARCHAR(MAX) NOT NULL, 
    [BannerPicctureURL] NVARCHAR(MAX) NOT NULL
)
