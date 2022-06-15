CREATE PROCEDURE [dbo].[spStep_Insert]
	@RecipeId nvarchar(128),
	@Details nvarchar(max),
	@Number int
	
AS
begin
	insert into dbo.RecipeStep(RecipeId,Details,Number)
	values(@RecipeId,@Details,@Number);
end
