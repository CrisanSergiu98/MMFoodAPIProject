CREATE PROCEDURE [dbo].[spIngredient_GetAll]
AS
begin
	set nocount on;

	SELECT * 
	from dbo.Ingredient
	order by [Name];
end
