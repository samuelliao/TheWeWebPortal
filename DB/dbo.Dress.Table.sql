USE [TheWe]
GO
/****** Object:  Table [dbo].[Dress]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dress](
	[Id] [uniqueidentifier] NOT NULL,
	[DressId] [varchar](10) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Category] [uniqueidentifier] NULL,
	[Color] [uniqueidentifier] NULL,
	[Type] [uniqueidentifier] NULL,
	[Neckline] [uniqueidentifier] NULL,
	[Trailing] [uniqueidentifier] NULL,
	[Back] [uniqueidentifier] NULL,
	[Shoulder] [uniqueidentifier] NULL,
	[Material] [uniqueidentifier] NULL,
	[Worn] [uniqueidentifier] NULL,
	[Veil] [uniqueidentifier] NULL,
	[Fitting] [uniqueidentifier] NULL,
	[Corsage] [uniqueidentifier] NULL,
	[Gloves] [uniqueidentifier] NULL,
	[Other] [uniqueidentifier] NULL,
	[Supplier] [uniqueidentifier] NULL,
	[PurchaseDate] [date] NULL,
	[PurchaseCosts] [money] NULL,
	[ModifyingCost] [money] NULL,
	[RentalCosts] [money] NULL,
	[RentPrice] [money] NULL,
	[AmortizationCosts] [money] NULL,
	[DepreciatioStartDate] [date] NULL,
	[DepreciableLife] [varchar](50) NULL,
	[DepreciationTerminationDate] [date] NULL,
	[DepreciationAmortization] [money] NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[UseStatus] [uniqueidentifier] NULL,
	[StoreId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Dress] ADD  CONSTRAINT [DF_DressList_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_Store]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressBack] FOREIGN KEY([Back])
REFERENCES [dbo].[DressBack] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressBack]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressCategory]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressColor] FOREIGN KEY([Color])
REFERENCES [dbo].[DressColor] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressColor]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressMaterial] FOREIGN KEY([Material])
REFERENCES [dbo].[DressMaterial] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressMaterial]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressNeckline] FOREIGN KEY([Material])
REFERENCES [dbo].[DressNeckline] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressNeckline]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressOther] FOREIGN KEY([Other])
REFERENCES [dbo].[DressOther] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressOther]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressShoulder] FOREIGN KEY([Shoulder])
REFERENCES [dbo].[DressShoulder] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressShoulder]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressStatusCode]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressSupplier] FOREIGN KEY([Supplier])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressSupplier]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressTrailing] FOREIGN KEY([Trailing])
REFERENCES [dbo].[DressTrailing] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressTrailing]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressType] FOREIGN KEY([Type])
REFERENCES [dbo].[DressType] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressType]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressUseStatus] FOREIGN KEY([UseStatus])
REFERENCES [dbo].[DressUseStatus] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressUseStatus]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_DressList_DressWorn] FOREIGN KEY([Worn])
REFERENCES [dbo].[DressWorn] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_DressList_DressWorn]
GO
