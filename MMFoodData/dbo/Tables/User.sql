CREATE TABLE [dbo].[User]
(	
    [Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(180) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [BusinessId] INT NULL, 
    CONSTRAINT [FK_User_ToBusiness] FOREIGN KEY (BusinessId) REFERENCES Business(Id)
)
