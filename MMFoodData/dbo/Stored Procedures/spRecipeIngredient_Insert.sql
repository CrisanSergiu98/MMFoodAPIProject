CREATE PROCEDURE [dbo].[spRecipeIngredient_Insert]	
	@IngredientId int,
	@RecipeId int,
	@Quantity float,
	@Unit nvarchar(50)
AS
begin
	set nocount on;

	insert into dbo.RecipeIngredient(IngredientId,RecipeId,Quantity,Unit)
	values(@IngredientId,@RecipeId,@Quantity,@Unit);
end