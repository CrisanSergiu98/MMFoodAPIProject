CREATE PROCEDURE [dbo].[spCategory_Insert]	
	@Id int output,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@PictureUrl nvarchar(max)
AS
begin
	set nocount on;

	insert into dbo.RecipeCategory([Name], [Description], PictureUrl)
	values(@Name, @Description, @PictureUrl);
end