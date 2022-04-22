CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
begin
	set nocount on;

	select Id, Username, Email, CreateDate 
	From [dbo].[User]
	Where Id = @Id
end
