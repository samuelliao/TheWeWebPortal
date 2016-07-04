USE [TheWe]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NULL,
	[Sn] [varchar](10) NULL,
	[Name] [varchar](10) NULL,
	[PassportName] [varchar](50) NULL,
	[Account] [varchar](50) NULL,
	[Nickname] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Addr] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[CellPhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Bday] [date] NULL,
	[Remark] [varchar](50) NULL,
	[IsValid] [bit] NULL,
	[MessengerType] [uniqueidentifier] NULL,
	[MessengerId] [varchar](50) NULL,
	[StoreId] [uniqueidentifier] NULL,
	[Gender] [bit] NULL,
	[InfoSource] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Country]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Customer] FOREIGN KEY([Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Customer]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Messenger] FOREIGN KEY([MessengerType])
REFERENCES [dbo].[Messenger] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Messenger]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Store]
GO
