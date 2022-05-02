CREATE PROCEDURE [dbo].[spRecipeIngredient_Insert]	
	@IngredientId int,
	@RecipeId int,
	@Quantity float,
	@Unit nvarchar,
	@IsRequired bit
AS
begin
	set nocount on;

	insert into dbo.RecipeIngredient(IngredientId,RecipeId,Quantity,Unit,IsRequired)
	values(@IngredientId,@RecipeId,@Quantity,@Unit,@IsRequired);
end