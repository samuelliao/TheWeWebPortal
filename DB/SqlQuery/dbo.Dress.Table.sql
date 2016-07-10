USE [TheWe]
GO
/****** Object:  Table [dbo].[Dress]    Script Date: 2016/7/10 下午 06:09:26 ******/
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
	[Fitting] [bit] NULL,
	[Corsage] [uniqueidentifier] NULL,
	[Gloves] [uniqueidentifier] NULL,
	[Other] [bit] NULL,
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
	[SellsPrice] [money] NULL,
 CONSTRAINT [PK__DressLis__3214EC07D063A5AE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Dress] ADD  CONSTRAINT [DF_DressList_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressBack] FOREIGN KEY([Back])
REFERENCES [dbo].[DressBack] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressBack]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressCategory]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressColor] FOREIGN KEY([Color])
REFERENCES [dbo].[DressColor] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressColor]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressCorsage] FOREIGN KEY([Corsage])
REFERENCES [dbo].[DressCorsage] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressCorsage]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressGloves] FOREIGN KEY([Gloves])
REFERENCES [dbo].[DressGloves] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressGloves]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressMaterial] FOREIGN KEY([Material])
REFERENCES [dbo].[DressMaterial] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressMaterial]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressNeckline] FOREIGN KEY([Neckline])
REFERENCES [dbo].[DressNeckline] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressNeckline]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressShoulder] FOREIGN KEY([Shoulder])
REFERENCES [dbo].[DressShoulder] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressShoulder]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressStatusCode]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressSupplier] FOREIGN KEY([Supplier])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressSupplier]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressTrailing] FOREIGN KEY([Trailing])
REFERENCES [dbo].[DressTrailing] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressTrailing]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressType] FOREIGN KEY([Type])
REFERENCES [dbo].[DressType] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressType]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressUseStatus] FOREIGN KEY([UseStatus])
REFERENCES [dbo].[DressUseStatus] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressUseStatus]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressVeil] FOREIGN KEY([Veil])
REFERENCES [dbo].[DressVeil] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressVeil]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_DressWorn] FOREIGN KEY([Worn])
REFERENCES [dbo].[DressWorn] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_DressWorn]
GO
ALTER TABLE [dbo].[Dress]  WITH CHECK ADD  CONSTRAINT [FK_Dress_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Dress] CHECK CONSTRAINT [FK_Dress_Store]
GO
