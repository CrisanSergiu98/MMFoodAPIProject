CREATE PROCEDURE [dbo].[spRecipe_Insert]
	@Id int,
	@UserId nvarchar(128),
	@CategoryId int,
	@Title nvarchar(50),
	@Description nvarchar(50),
	@PictureUrl nvarchar(128),
	@IsPublished bit
AS
begin
	set nocount on;

	insert into dbo.Recipe(UserId, CategoryId, Title, [Description], PictureUrl, IsPublished)
	values(@UserId, @CategoryId, @Title, @Description, @PictureUrl, @IsPublished);
end
