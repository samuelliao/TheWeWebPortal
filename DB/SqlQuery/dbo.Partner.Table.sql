USE [TheWe]
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partner](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Partner_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[EngName] [nvarchar](50) NULL,
	[Bday] [date] NULL,
	[MessengerType] [uniqueidentifier] NULL,
	[MessengerId] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[OrderId] [uniqueidentifier] NULL,
	[Email] [varchar](50) NULL,
	[Works] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[PhotoImg] [varchar](50) NULL,
	[EnBday] [varbinary](max) NULL,
	[EnMessengerId] [varbinary](max) NULL,
	[EnPhone] [varbinary](max) NULL,
	[EnEmail] [varbinary](max) NULL,
	[EnPhotoImg] [varbinary](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Partner__IsDelet__532343BF]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Partner]  WITH CHECK ADD  CONSTRAINT [FK_Partner_Messenger] FOREIGN KEY([MessengerType])
REFERENCES [dbo].[Messenger] ([Id])
GO
ALTER TABLE [dbo].[Partner] CHECK CONSTRAINT [FK_Partner_Messenger]
GO
ALTER TABLE [dbo].[Partner]  WITH CHECK ADD  CONSTRAINT [FK_Partner_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[Partner] CHECK CONSTRAINT [FK_Partner_OrderInfo]
GO
ALTER TABLE [dbo].[Partner]  WITH CHECK ADD  CONSTRAINT [FK_Partner_Partner] FOREIGN KEY([Id])
REFERENCES [dbo].[Partner] ([Id])
GO
ALTER TABLE [dbo].[Partner] CHECK CONSTRAINT [FK_Partner_Partner]
GO
