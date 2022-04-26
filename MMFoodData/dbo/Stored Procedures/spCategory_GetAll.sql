CREATE PROCEDURE [dbo].[spCategory_GetAll]
AS
begin
	set nocount on;

	SELECT Id, [Name], [Description], PictureURL
	from dbo.RecipeCategory
	order by [Name];
end
