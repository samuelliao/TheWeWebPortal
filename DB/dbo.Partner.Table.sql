USE [TheWe]
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partner](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[EnName] [varchar](50) NULL,
	[Bday] [date] NULL,
	[MessengerType] [uniqueidentifier] NULL,
	[MessengerId] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[Email] [varchar](50) NULL,
	[Works] [varchar](50) NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Partner] ADD  CONSTRAINT [DF_Partner_Id]  DEFAULT (newid()) FOR [Id]
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
