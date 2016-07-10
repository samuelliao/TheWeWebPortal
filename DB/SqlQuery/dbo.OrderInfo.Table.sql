USE [TheWe]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[ConsultId] [uniqueidentifier] NULL,
	[Sn] [varchar](10) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[PartnerId] [uniqueidentifier] NOT NULL,
	[StatusId] [uniqueidentifier] NOT NULL,
	[CloseTime] [datetime] NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[AreaId] [uniqueidentifier] NOT NULL,
	[ChurchId] [uniqueidentifier] NOT NULL,
	[SetId] [uniqueidentifier] NOT NULL,
	[ServiceWindowId] [uniqueidentifier] NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
	[Price] [money] NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[Deposit] [money] NULL,
	[HotelName] [varchar](max) NULL,
	[CustomerImg] [varchar](max) NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Area]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Church] FOREIGN KEY([ChurchId])
REFERENCES [dbo].[Church] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Church]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_ConferenceItem] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ConferenceItem] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_ConferenceItem]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Consultation] FOREIGN KEY([ConsultId])
REFERENCES [dbo].[Consultation] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Consultation]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Country]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Currency]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Customer]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_OrderInfo] FOREIGN KEY([Id])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_OrderInfo]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Partner] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[Partner] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Partner]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_ProductSet] FOREIGN KEY([SetId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_ProductSet]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_ServiceWindow] FOREIGN KEY([ServiceWindowId])
REFERENCES [dbo].[ServiceWindow] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_ServiceWindow]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_Store]
GO
