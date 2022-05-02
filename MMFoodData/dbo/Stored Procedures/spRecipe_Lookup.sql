CREATE PROCEDURE [dbo].[spRecipe_Lookup]
	@Title nvarchar(50),
	@UserId nvarchar(128)
AS
begin
	set nocount on;

	select Id 
	from dbo.Recipe
	where Title = @Title and UserId = @UserId;
end
