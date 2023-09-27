CREATE TABLE [dbo].[EmailMessages](
	[Id] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](500) NULL,
	[Body] [nvarchar](max) NULL,
	[ToAddresses] [nvarchar](max) NULL,
	[CcAddresses] [nvarchar](max) NULL,
	[BccAddresses] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmailMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmailMessages] ADD  CONSTRAINT [DF_EmailMessages_Id]  DEFAULT (newid()) FOR [Id]
GO
