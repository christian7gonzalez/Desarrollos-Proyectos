CREATE DATABASE ContactSA
GO
USE ContactSA
GO
CREATE TABLE Contact
(
	id int IDENTITY(1,1),
	firstName VARCHAR(50) NOT NULL,
	lastName VARCHAR(50) NOT NULL,
	company VARCHAR(30) NOT NULL,
	email VARCHAR(50) NOT NULL,
	phoneNumber VARCHAR(15) NOT NULL 
	PRIMARY KEY (id)
)
GO
--Datos de prueba
INSERT INTO Contact
VALUES ('Sujeto1', 'Prueba1','Google','Sujeto1.Prueba1@Google.com.ar','+542228473656')
GO
INSERT INTO Contact
VALUES ('Sujeto2', 'Prueba2','Google','Sujeto2.Prueba2@Google.com.ar','0222415212343')
