USE [TheWe]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_OrderInfo_Id]  DEFAULT (newid()),
	[ConsultId] [uniqueidentifier] NULL,
	[Sn] [nvarchar](max) NULL,
	[StartTime] [datetime] NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[PartnerId] [uniqueidentifier] NULL,
	[StatusId] [uniqueidentifier] NULL,
	[CloseTime] [datetime] NULL,
	[CountryId] [uniqueidentifier] NULL,
	[AreaId] [uniqueidentifier] NULL,
	[ChurchId] [uniqueidentifier] NULL,
	[SetId] [uniqueidentifier] NULL,
	[ServiceWindowId] [uniqueidentifier] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[PermissionId] [uniqueidentifier] NULL,
	[Price] [money] NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[DepositFirst] [money] NULL,
	[HotelName] [nvarchar](max) NULL,
	[CustomerImg] [varchar](max) NULL,
	[BookingDate] [datetime] NULL,
	[OverseaWeddingDate] [datetime] NULL,
	[DepositFirstDate] [datetime] NULL,
	[DepositSecondDate] [datetime] NULL,
	[DepositSecond] [money] NULL,
	[OverseaFilmDate] [datetime] NULL,
	[LocalFilmingDate] [datetime] NULL,
	[LocalEngagementDate] [datetime] NULL,
	[LocalWeddingDate] [datetime] NULL,
	[LocalMotheringDate] [datetime] NULL,
	[LocalReceptionDate] [datetime] NULL,
	[BalancePayementDate] [datetime] NULL,
	[ServiceType] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__OrderInfo__IsDel__5046D714]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__OrderInfo__Updat__4F089A18]  DEFAULT (getdate()),
	[ConferenceCategory] [uniqueidentifier] NULL,
	[WeddingRecord] [uniqueidentifier] NULL,
	[DynamicRecord] [uniqueidentifier] NULL,
	[BridalSecretary] [uniqueidentifier] NULL,
	[WeddingPerform] [uniqueidentifier] NULL,
	[WeddingDecorate] [uniqueidentifier] NULL,
	[WeddingHost] [uniqueidentifier] NULL,
	[TotalPrice] [money] NULL,
	[Discount] [money] NULL,
	[Remark] [nvarchar](max) NULL,
	[Referral] [nvarchar](50) NULL,
	[WeddingType] [nvarchar](50) NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[Img] [varchar](max) NULL,
	[DepositFirstType] [nvarchar](50) NULL,
	[DepositSecondType] [nvarchar](50) NULL,
	[BalancePayementType] [nvarchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__OrderInfo__Creat__26D08B8C]  DEFAULT (getdate()),
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_ServiceItemCategory] FOREIGN KEY([ServiceType])
REFERENCES [dbo].[ServiceItemCategory] ([Id])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_ServiceItemCategory]
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
