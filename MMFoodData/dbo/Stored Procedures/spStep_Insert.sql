CREATE PROCEDURE [dbo].[spStep_Insert]
	@RecipeId nvarchar(128),
	@Title nvarchar(50),
	@Details nvarchar(max),
	@Number int
	
AS
begin
	insert into dbo.RecipeStep(RecipeId,Title,Details,Number)
	values(@RecipeId,@Title,@Details,@Number);
end
