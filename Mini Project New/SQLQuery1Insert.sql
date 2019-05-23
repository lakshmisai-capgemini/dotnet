
INSERT INTO Customers(CustId,Name,Address,Telephone,Gender,Dob,Smoker,Hobbies)VALUES(3,'Arun','Bangalore','9490187840','Male','2/28/1996','smoker','playing cricket')

INSERT INTO Logins(LoginId,Password,CustomerId) VALUES('Customer3','pass',3)

SELECT * FROM Customers


INSERT INTO InsuranceProducts(ProductId,Products,ProductType) VALUES(2,'policy for HumanBeings','Life')

INSERT INTO Policys(PolicyNumber,Customerno,ProductId,InsuredName,InsuredAge,Nominee,Relation) VALUES(4,3,2,'Aravind',32,'Kamal','Brother')

Update Policys 
Set PremiumPaymentFrequency='Monthly'
WHERE PolicyNumber=1

SELECT * FROM InsuranceProducts