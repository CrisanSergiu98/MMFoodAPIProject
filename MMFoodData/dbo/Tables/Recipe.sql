CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [PictureURL] NVARCHAR(50) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Published] BIT NOT NULL, 
    [Public] BIT NOT NULL
    
)
