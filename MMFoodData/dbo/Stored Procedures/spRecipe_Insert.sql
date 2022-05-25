CREATE PROCEDURE [dbo].[spRecipe_Insert]
	@Id int output,
	@Title nvarchar,
	@Description nvarchar,
	@PictureUrl nvarchar,
	@CreateDate datetime2,
	@CategoryId int,
	@QuisineId int,	
	@UserId nvarchar,
	@IsPublished bit
AS
begin
	set nocount on;
	insert into dbo.Recipe(Title, [Description], PictureUrl, CreateDate, CategoryId, QuisineId, UserId, IsPublished)
	values(@Title, @Description, @PictureUrl, @CreateDate, @CategoryId, @QuisineId, @UserId, @IsPublished);
	
	select @Id= SCOPE_IDENTITY();
end
