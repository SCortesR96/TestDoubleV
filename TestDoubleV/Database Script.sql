CREATE TABLE people(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Lastname VARCHAR(255) NOT NULL,
	Email VARCHAR(255) UNIQUE NOT NULL,
	DocumentNumber VARCHAR(255) UNIQUE NOT NULL,
	DocumentType VARCHAR(255) NOT NULL,
	FullName VARCHAR(255) NOT NULL,
	FullDocument VARCHAR(255) UNIQUE NOT NULL,
	CreatedAt DateTime DEFAULT GETDATE(),
);
GO;

CREATE TABLE users(
	Id int unique identity(1,1),
	PersonId INT NOT NULL,
	Username VARCHAR(255) UNIQUE NOT NULL,
	Password VARCHAR(255) NOT NULL,
	CreatedAt DateTime DEFAULT GETDATE(),
	CONSTRAINT UC_Person UNIQUE (Username),
	FOREIGN KEY (PersonId) REFERENCES people(id)
);
GO;

CREATE PROCEDURE [dbo].[SP_CreatePeopleAndUser] 
	@Name VARCHAR(255),
	@Lastname VARCHAR(255),
	@Email VARCHAR(255),
	@DocumentNumber VARCHAR(255),
	@DocumentType VARCHAR(255),
	@Username VARCHAR(255),
	@Password VARCHAR(255)
AS
	INSERT INTO dbo.people
	(
		Name,
		Lastname,
		Email,
		DocumentNumber,
		DocumentType,
		FullName,
		FullDocument
	)
	Values
	(
		@Name,
		@Lastname,
		@Email,
		@DocumentNumber,
		@DocumentType,
		CONCAT(@Name, ' ', @Lastname),
		CONCAT(@DocumentNumber,@DocumentType)
	);

	DECLARE @PersonId INT;
	SET @PersonId = SCOPE_IDENTITY();

	INSERT INTO dbo.users (PersonId, Username, Password) values ((SELECT @PersonId), @Username, @Password);
GO;


CREATE PROCEDURE [dbo].[SP_Login] 
	@Username VARCHAR(255),
	@Password VARCHAR(255)
AS
	SELECT *
	FROM dbo.users
	WHERE userName = @Username
		AND Password = @Password;
