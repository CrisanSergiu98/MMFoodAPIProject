CREATE PROCEDURE [dbo].[spCategory_SearchByName]
	@Name nvarchar(50)
AS
begin
	set nocount on;
	select *
	from dbo.RecipeCategory
	where [Name] like '%' + @Name + '%';
	--where [Name] = @Name;
end

