--SP Modificar Contact --
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Contact_M')
DROP PROCEDURE Contact_M
GO
CREATE PROCEDURE Contact_M
	@id INT,  
	@firstName VARCHAR(50),
	@lastName VARCHAR(50),
	@company VARCHAR(50),
	@email VARCHAR(50),
	@phoneNumber VARCHAR(15)
AS
	UPDATE Contacts 
	SET firstName = @firstName, 
	lastName = @lastName, 
	company = @company, 
	email = @email, 
	phoneNumber = @phoneNumber 
	WHERE id = @id

