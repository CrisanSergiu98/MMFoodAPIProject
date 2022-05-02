CREATE PROCEDURE [dbo].[spIngredientCategory_Lookup]
	@Name nvarchar(50)
AS
begin
	set nocount on;

	select Id 
	from dbo.IngredientCategory
	where [Name]=@Name;
end
