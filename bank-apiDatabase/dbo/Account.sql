CREATE TABLE [dbo].[Account]
(
	[AccountId] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[AccountNumber] VARCHAR(50) NOT NULL UNIQUE,
	[CustomerId] BIGINT NOT NULL,
	[DateCreatedUtc] DATETIME NOT NULL,
	[DateUpdatedUtc] DATETIME NULL,
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])
)