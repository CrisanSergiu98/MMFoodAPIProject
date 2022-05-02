CREATE PROCEDURE [dbo].[spIngredient_Lookup]
	@Name nvarchar
AS
	set nocount on;
	SELECT Id
	from dbo.Ingredient
	where [Name] = @Name;
RETURN 0
