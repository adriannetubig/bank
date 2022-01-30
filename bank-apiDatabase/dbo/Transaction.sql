CREATE TABLE [dbo].[Transaction]
(
	[TransactionId] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TransactionGuid] UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[FromAccountId] BIGINT NOT NULL,
	[ToAccountId] BIGINT NOT NULL,
	[Amount] DECIMAL(19,4) NOT NULL,
	[TransactionDateUtc] DATETIME NOT NULL,
	[CustomerId] BIGINT NOT NULL,
	[DateCreatedUtc] DATETIME NOT NULL,
	[DateUpdatedUtc] DATETIME NULL,
    FOREIGN KEY ([FromAccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    FOREIGN KEY ([ToAccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])
)