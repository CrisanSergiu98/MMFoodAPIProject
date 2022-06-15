CREATE PROCEDURE [dbo].[spIngredient_Insert]	
	@Id int output,
	@Name nchar(50),
	@Description nvarchar(max),
	@PictureUrl nvarchar(max),		
	@CategoryId int
AS
begin
	set nocount on;

	insert into dbo.Ingredient([Name], [Description], PictureUrl, CategoryId)
	values(@Name, @Description, @PictureUrl, @CategoryId);
end
