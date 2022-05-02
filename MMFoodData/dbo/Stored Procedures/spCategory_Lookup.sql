CREATE PROCEDURE [dbo].[spCategory_Lookup]
	@Name nvarchar(50)
AS
begin
	set nocount on;

	select Id 
	from dbo.RecipeCategory
	where [Name]=@Name;
end
