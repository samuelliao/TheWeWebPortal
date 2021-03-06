USE [TheWe]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Customer_Id]  DEFAULT (newid()),
	[CountryId] [uniqueidentifier] NULL,
	[Sn] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[Account] [varchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Password] [varchar](max) NULL,
	[Addr] [varchar](max) NULL,
	[Phone] [varchar](50) NULL,
	[CellPhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Bday] [date] NULL,
	[Remark] [nvarchar](max) NULL,
	[IsValid] [bit] NULL,
	[MessengerType] [uniqueidentifier] NULL,
	[MessengerId] [varchar](50) NULL,
	[StoreId] [uniqueidentifier] NULL,
	[Gender] [bit] NULL,
	[MsgTitle] [nvarchar](50) NULL,
	[PhotoImg] [varchar](max) NULL,
	[EnAddr] [varbinary](max) NULL,
	[EnPhone] [varbinary](max) NULL,
	[EnCellPhone] [varbinary](max) NULL,
	[EnEmail] [varbinary](max) NULL,
	[EnMessengerId] [varbinary](max) NULL,
	[EnPhotoImg] [varbinary](max) NULL,
	[EnBday] [varbinary](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Customer__IsDele__2FDA0782]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Customer__Update__2DA7A64D]  DEFAULT (getdate()),
	[Works] [nvarchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__Customer__Create__047B7388]  DEFAULT (getdate()),
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

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
