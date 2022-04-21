CREATE TABLE [dbo].[Business]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NOT NULL, 
    [Location] NCHAR(10) NOT NULL, 
    [ProfilePictureURL] NCHAR(10) NOT NULL, 
    [BannerPicctureURL] NCHAR(10) NOT NULL

)
