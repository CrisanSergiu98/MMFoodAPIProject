CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [PictureUrl] NVARCHAR(MAX) NULL, 
    [CreateDate] DATETIME2 NULL DEFAULT getutcdate(), 
    [CategoryId] INT NOT NULL, 
    [QuisineId] INT NULL,     
    [UserId] NVARCHAR(128) NOT NULL, 
    [IsPublished] BIT NULL,     
    
    CONSTRAINT [FK_Recipe_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id), 
    CONSTRAINT [FK_Recipe_ToRecipeCategory] FOREIGN KEY (CategoryId) REFERENCES RecipeCategory(Id), 
    CONSTRAINT [FK_Recipe_ToQuisine] FOREIGN KEY (QuisineId) REFERENCES Quisine(Id)
    
)
