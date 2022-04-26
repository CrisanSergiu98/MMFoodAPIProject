CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [PictureURL] NVARCHAR(50) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Published] BIT NOT NULL, 
    [Public] BIT NOT NULL,     
    CONSTRAINT [FK_Recipe_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id), 
    CONSTRAINT [FK_Recipe_ToRecipeCategory] FOREIGN KEY (CategoryId) REFERENCES RecipeCategory(Id)
    
)
