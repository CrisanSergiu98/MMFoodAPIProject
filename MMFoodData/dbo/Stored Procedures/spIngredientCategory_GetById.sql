CREATE PROCEDURE [dbo].[spIngredientCategory_GetById]
	@Id int
AS
begin
	set nocount on;

	select * 
	from dbo.IngredientCategory
	where Id=@Id
end
