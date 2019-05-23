IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='Customers')
DROP TABLE Customers
GO
CREATE TABLE Customers(
                       CustId INT PRIMARY KEY,
                       Name VARCHAR(30),
					   Address VARCHAR(100),
					   Telephone VARCHAR(50),
					   Gender VARCHAR(10),
					   Dob DateTime,
					   Smoker VARCHAR(20),
					   Hobbies VARCHAR(100),
					   Createid VARCHAR(30) DEFAULT System_user,
					   CreateDate DATETIME DEFAULT GETDATE(),
					   Updateid VARCHAR(30) DEFAULT System_user,
					   UpdateDate DATETIME DEFAULT GETDATE()
					   )
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='InsuranceProducts')
DROP TABLE InsuranceProducts
 
CREATE TABLE InsuranceProducts(
                               ProductId INT PRIMARY KEY,							  
                               Products VARCHAR(100),
							   Createid VARCHAR(30) DEFAULT System_user,
					           CreateDate DATETIME DEFAULT GETDATE(),
					           Updateid VARCHAR(30) DEFAULT System_user,
					           UpdateDate DATETIME DEFAULT GETDATE()    
							   )  
GO							   
							    
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='Policys')
DROP TABLE Policys

CREATE TABLE Policys(
                      PolicyNumber VARCHAR(20) PRIMARY KEY,
					  Customerno INT FOREIGN KEY REFERENCES Customers(CustId),
					  ProductId INT FOREIGN KEY REFERENCES InsuranceProducts(ProductId),					  
					  Createid VARCHAR(30) DEFAULT System_user,
					  CreateDate DATETIME DEFAULT GETDATE(),
					  Updateid VARCHAR(30) DEFAULT System_user,
					  UpdateDate DATETIME DEFAULT GETDATE() 	
				  )

GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='Endorsement')
DROP TABLE Endorsement

CREATE TABLE Endorsement(
                            TransactionId  INT IDENTITY(1,1) PRIMARY KEY ,
					  		CustId INT FOREIGN KEY REFERENCES Customers(CustId),
							ProductId INT  FOREIGN KEY REFERENCES InsuranceProducts(ProductId),
							Policynumber VARCHAR(20)  FOREIGN KEY REFERENCES Policys(PolicyNumber),
							Createid VARCHAR(30) DEFAULT System_user,
					        CreateDate DATETIME DEFAULT GETDATE(),
					        Updateid VARCHAR(30) DEFAULT System_user,
					        UpdateDate DATETIME DEFAULT GETDATE() 
							)	
GO		

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='Logins')
DROP TABLE Logins

CREATE TABLE Logins(
                    LoginId VARCHAR(30) PRIMARY KEY,
					Password VARCHAR(30),
					CustomerId INT  FOREIGN KEY REFERENCES Customers(CustId),
					Createid VARCHAR(30) DEFAULT System_user,
				    CreateDate DATETIME DEFAULT GETDATE(),
					Updateid VARCHAR(30) DEFAULT System_user,
					UpdateDate DATETIME DEFAULT GETDATE() 
					)
GO





ALTER TABLE InsuranceProducts add ProductType VARCHAR(30)

       

ALTER TABLE Policys ADD InsuredName VARCHAR(30)

ALTER TABLE Policys ADD InsuredAge INT

ALTER TABLE Policys ADD Nominee VARCHAR(30)

ALTER TABLE Policys ADD Relation VARCHAR(20)

ALTER TABLE Policys ADD PremiumPaymentFrequency VARCHAR(20)



ALTER TABLE Endorsement Add InsuredName VARCHAR(30)

ALTER TABLE Endorsement ADD InsuredAge INT

ALTER TABLE Endorsement ADD Dob DATETIME

ALTER TABLE Endorsement ADD Gender VARCHAR(20)

ALTER TABLE Endorsement Add Nominee VARCHAR(30)

ALTER TABLE Endorsement ADD Relation VARCHAR(20)

ALTER TABLE Endorsement ADD Smoker VARCHAR(20)

ALTER TABLE Endorsement Add Address VARCHAR(100)

ALTER TABLE Endorsement Add Telephone VARCHAR(50)

ALTER TABLE Endorsement Add PremiumPaymentFrequency VARCHAR(20)

ALTER TABLE Endorsement ADD EndorsementStatus VARCHAR(20)



IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='prcShowPolicy')
DROP PROC prcShowPolicy

GO
CREATE PROC prcShowPolicy
AS 
BEGIN
   SELECT * FROM Policys
END
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='prcShowCustomer')
DROP PROC prcShowCustomer

go
CREATE PROC prcShowCustomer
As
BEGIN
  SELECT * FROM Customers
  END
  GO
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name='prcShowLogin')
DROP PROC prcShowLogin
GO
CREATE PROC prcShowLogin
As
BEGIN
SELECT * FROM Logins
END
GO

CREATE PROC prcShowInsuranceProduct
AS
BEGIN
SELECT * FROM InsuranceProducts
END


GO
CREATE PROC prcShowEndorsement
As
BEGIN
SELECT * FROM Endorsement
END

SELECT * FROM Customers
GO
CREATE PROC prcInsertPolicy
                @policynum VARCHAR(20),
				@custno INT,
				@prodId INT,
				@insuName VARCHAR(30),
				@age INT,
				@nominee VARCHAR(30),
				@relation VARCHAR(30),
				@payFreq VARCHAR(30)
AS
INSERT INTO Policys(PolicyNumber,Customerno,ProductId,InsuredName,InsuredAge,Nominee,Relation,PremiumPaymentFrequency) VALUES(@policynum,@custno,@prodId,@insuName,@age,@nominee,@relation,@payFreq)
Go
