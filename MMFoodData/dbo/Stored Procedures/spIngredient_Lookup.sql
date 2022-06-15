CREATE PROCEDURE [dbo].[spIngredient_Lookup]
	@Name nvarchar(50)
AS
	set nocount on;
	SELECT Id
	from dbo.Ingredient
	where [Name] = @Name;
RETURN 0
