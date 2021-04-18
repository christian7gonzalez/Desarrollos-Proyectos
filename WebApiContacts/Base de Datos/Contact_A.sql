--SP CREATE Contact--
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Contact_A')
DROP PROCEDURE Contact_A
GO
CREATE PROCEDURE Contact_A
	@firstName VARCHAR(50),
    @lastName VARCHAR(50),
    @company VARCHAR(50),
    @email VARCHAR(50),
    @phoneNumber VARCHAR(15)
AS
	INSERT INTO Contact
	VALUES(@firstName,@lastName,@company,@email,@phoneNumber)
	SELECT @@IDENTITY
GO