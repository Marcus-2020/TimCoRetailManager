CREATE PROCEDURE  dto.[spUserLookup]
    @Id nvarchar(128)
AS
BEGIN
    set nocount on;

    select Id, FirstName, LastName, EmailAddress, CreatedDate
    from dto.[User]
    where Id = @Id;
END;

CREATE PROCEDURE  dto.[spProductGetAll]
AS
BEGIN
    set nocount on;

    select Id, ProductName, [Description], RetailPrice, QuantityInStock
    from dto.[Product] as p
    order by p.ProductName
END;