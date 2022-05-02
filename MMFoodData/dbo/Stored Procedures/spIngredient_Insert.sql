CREATE PROCEDURE [dbo].[spIngredient_Insert]	
	@Id int output,
	@Name nchar(50),
	@Description nvarchar(128),
	@PictureUrl nvarchar(128),		
	@CategoryId int
AS
begin
	set nocount on;

	insert into dbo.Ingredient([Name], [Description], PictureUrl, CategoryId)
	values(@Name, @Description, @PictureUrl, @CategoryId);
end
