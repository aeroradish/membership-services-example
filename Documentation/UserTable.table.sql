
/****** Object:  Table [dbo].[Users]    Script Date: 4/19/2015 2:35:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IsConfirmed] [bit] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordVerificationToken] [nvarchar](50) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
	[EmailResult] [bit] NULL,
	[IsActive] [bit] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[TimeZone] [nvarchar](25) NULL,
	[Culture] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserId]  DEFAULT (newid()) FOR [UserId]
GO


