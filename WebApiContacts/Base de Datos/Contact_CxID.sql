--SP SELECT Contact por id--
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Contact_CxID')
DROP PROCEDURE Contact_CxID
GO
CREATE PROCEDURE Contact_CxID
	@id INT    
AS
	SELECT * FROM Contact WHERE id = @id

