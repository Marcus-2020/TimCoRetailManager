CREATE PROCEDURE  dto.[spUserlookup]
    @Id nvarchar(128)
AS
BEGIN
    set nocount on;

    select FirstName, LastName, EmailAddress
    from dto.[User]
    where Id = @Id;
END