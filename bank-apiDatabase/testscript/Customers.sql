IF NOT EXISTS(SELECT 1 FROM Customer)
BEGIN
	INSERT INTO Customer
		(CustomerGuid, FirstName, LastName, DateCreatedUtc)
	VALUES
		('78cf59a3-3e43-4897-9bab-bfdf30b41e84', 'John', 'Smith', GETUTCDATE()),
		('3eb148e5-14de-4177-a3c5-e357be474712', 'Jane', 'Citizen', GETUTCDATE()),
		('be9c4f94-0993-4b8f-a9bb-bf3b2ded22bc', 'Customer', '1', GETUTCDATE()),
		('5e61801c-73d5-4f0c-8030-0f43edd21751', 'Customer', '2', GETUTCDATE())
END