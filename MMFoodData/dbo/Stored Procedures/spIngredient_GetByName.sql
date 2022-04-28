CREATE PROCEDURE [dbo].[spIngredient_GetByName]
	@Name nchar
as
begin
	SELECT *
	from dbo.Ingredient
	where [Name] = @Name;
end
