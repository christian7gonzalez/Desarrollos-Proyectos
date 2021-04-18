--SP Baja Contact --
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Contact_B')
DROP PROCEDURE Contact_B
GO
CREATE PROCEDURE Contact_B
	@id INT  
AS
	DELETE FROM Contact WHERE id =@id

