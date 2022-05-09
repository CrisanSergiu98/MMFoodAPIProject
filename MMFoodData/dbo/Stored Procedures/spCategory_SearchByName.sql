CREATE PROCEDURE [dbo].[spCategory_SearchByName]
	@Name nvarchar
AS
begin
	set nocount on;
	select *
	from dbo.RecipeCategory
	--where [Name] like '%' + @Name + '%';
end

