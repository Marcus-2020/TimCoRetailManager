CREATE PROCEDURE  dto.[spUserLookup]
    @Id nvarchar(128)
AS
BEGIN
    set nocount on;

    select Id, FirstName, LastName, EmailAddress, CreatedDate
    from dto.[User]
    where Id = @Id;
END