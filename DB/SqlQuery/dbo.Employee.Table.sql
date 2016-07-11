USE [TheWe]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Employee_Id]  DEFAULT (newid()),
	[CountryId] [uniqueidentifier] NULL,
	[Sn] [varchar](10) NULL,
	[Name] [varchar](10) NULL,
	[Account] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Addr] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Bday] [date] NULL,
	[OnBoard] [date] NULL,
	[QuitDay] [date] NULL,
	[Salary] [money] NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[Remark] [varchar](max) NULL,
	[StoreId] [uniqueidentifier] NULL,
	[IsValid] [bit] NOT NULL,
	[EnAddr] [varbinary](max) NULL,
	[EnPhone] [varbinary](max) NULL,
	[EnBday] [varbinary](max) NULL,
	[EnSalary] [varbinary](max) NULL,
	[Addr2] [varchar](50) NULL,
	[PassportId] [varchar](50) NULL,
	[PassportName] [varchar](50) NULL,
	[IdCardImg] [varchar](max) NULL,
	[BankBookImg] [varchar](50) NULL,
	[BankAccount] [varchar](50) NULL,
	[EmContName] [varchar](50) NULL,
	[EmContPhone] [varchar](50) NULL,
	[EmContMail] [varchar](50) NULL,
	[PhotoImg] [varchar](max) NULL,
	[InsuranceId] [varchar](50) NULL,
	[EnAddr2] [varchar](max) NULL,
	[EnEmContPhone] [varbinary](max) NULL,
	[EnEmContMail] [varbinary](max) NULL,
	[EnPassportId] [varbinary](max) NULL,
	[PersonalId] [varchar](50) NULL,
	[EnPersonalId] [varbinary](max) NULL,
	[EnIdCardImg] [varbinary](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Country]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Currency]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Store]
GO
