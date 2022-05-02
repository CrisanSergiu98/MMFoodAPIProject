CREATE PROCEDURE [dbo].[spIngredient_GetById]
	@Id int
AS
begin
	set nocount on;

	select * 
	from dbo.Ingredient
	where Id=@Id
end
