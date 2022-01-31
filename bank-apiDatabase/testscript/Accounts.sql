IF NOT EXISTS(SELECT 1 FROM Account) AND EXISTS (SELECT 1 FROM Customer)
BEGIN
	INSERT INTO Account
		(AccountNumber, CustomerId, DateCreatedUtc)
	VALUES
		('123456', (SELECT CustomerId FROM Customer WHERE CustomerGuid = '78cf59a3-3e43-4897-9bab-bfdf30b41e84'), GETUTCDATE()),
		('135790', (SELECT CustomerId FROM Customer WHERE CustomerGuid = '3eb148e5-14de-4177-a3c5-e357be474712'), GETUTCDATE()),
		('123457', (SELECT CustomerId FROM Customer WHERE CustomerGuid = 'be9c4f94-0993-4b8f-a9bb-bf3b2ded22bc'), GETUTCDATE()),
		('789123', (SELECT CustomerId FROM Customer WHERE CustomerGuid = '5e61801c-73d5-4f0c-8030-0f43edd21751'), GETUTCDATE())
END