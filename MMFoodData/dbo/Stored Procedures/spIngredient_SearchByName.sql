CREATE PROCEDURE [dbo].[spIngredient_SearchByName]
	@Name nvarchar(50)
AS
begin
	set nocount on;

	select top 10 * 
	from dbo.Ingredient
	where [Name] like '%' + @Name + '%';
end
