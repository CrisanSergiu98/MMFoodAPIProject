CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    Title NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL,
    [PictureUrl] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [CategoryId] INT NOT NULL, 
    [QuisineId] INT NOT NULL,     
    [UserId] NVARCHAR(128) NOT NULL, 
    [IsPublished] BIT NOT NULL     
    
    --CONSTRAINT [FK_Recipe_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id), 
    --CONSTRAINT [FK_Recipe_ToRecipeCategory] FOREIGN KEY (CategoryId) REFERENCES RecipeCategory(Id), 
    --CONSTRAINT [FK_Recipe_ToQuisine] FOREIGN KEY (QuisineId) REFERENCES Quisine(Id)
    
)
