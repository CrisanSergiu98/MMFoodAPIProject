CREATE PROCEDURE [dbo].[spIngredientCategory_Insert]
	@Id int output,
	@Name nvarchar(50),
	@Description nvarchar(128),
	@PictureUrl nvarchar(128)
AS
begin
	set nocount on;

	insert into dbo.IngredientCategory([Name], [Description], PictureUrl)
	values(@Name, @Description, @PictureUrl);
end
