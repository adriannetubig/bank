IF NOT EXISTS(SELECT 1 FROM [Transaction]) AND EXISTS (SELECT 1 FROM Customer) AND EXISTS (SELECT 1 FROM Account)
BEGIN
	INSERT INTO [Transaction]
		(TransactionGuid, FromAccountId, ToAccountId, Amount, TransactionDate, CustomerId, [Description], DateCreatedUtc)
	VALUES
		('6976fe63-c665-445b-835c-42dabe9fa3b7',
			(SELECT AccountId FROM Account WHERE AccountNumber = '123456'),
			(SELECT AccountId FROM Account WHERE AccountNumber = '789123'),
			123456.78,
			'2022-01-31 04:53:26.760',
			(SELECT CustomerId FROM Customer WHERE CustomerGuid = '78cf59a3-3e43-4897-9bab-bfdf30b41e84'),
			'First transaction description',
			GETUTCDATE()),
		('05c17cad-9279-423c-b32b-cdb9e0e26d36',
			(SELECT AccountId FROM Account WHERE AccountNumber = '135790'),
			(SELECT AccountId FROM Account WHERE AccountNumber = '789123'),
			45678.33,
			'2022-01-31 04:53:26.760',
			(SELECT CustomerId FROM Customer WHERE CustomerGuid = '3eb148e5-14de-4177-a3c5-e357be474712'),
			'Second transaction description',
			GETUTCDATE()),
		('221142e2-8240-4196-80df-fce8a711c462',
			(SELECT AccountId FROM Account WHERE AccountNumber = '123457'),
			(SELECT AccountId FROM Account WHERE AccountNumber = '789123'),
			98765,
			'2022-01-31 04:53:26.760',
			(SELECT CustomerId FROM Customer WHERE CustomerGuid = 'be9c4f94-0993-4b8f-a9bb-bf3b2ded22bc'),
			'Third transaction description',
			GETUTCDATE())
END