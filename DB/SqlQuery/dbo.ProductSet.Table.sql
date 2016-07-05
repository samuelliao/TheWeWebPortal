USE [TheWe]
GO
/****** Object:  Table [dbo].[ProductSet]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSet](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[Decoration] [bit] NULL,
	[performence] [bit] NULL,
	[Price] [money] NULL,
	[PriceCurrencyId] [uniqueidentifier] NULL,
	[Cost] [money] NULL,
	[CostCurrencyId] [uniqueidentifier] NULL,
	[ChurchId] [uniqueidentifier] NOT NULL,
	[DmImg] [varchar](50) NULL,
	[ChurchCost] [bit] NULL,
	[Capacities] [bit] NULL,
	[Ceritficate] [bit] NULL,
	[RignPillow] [bit] NULL,
	[SignPen] [bit] NULL,
	[FlowerRain] [bit] NULL,
	[Champagne] [int] NULL,
	[BridalMakeup] [int] NULL,
	[GroomMakeup] [int] NULL,
	[WeddingFilmingTime] [int] NULL,
	[OtherFilmingTime] [int] NULL,
	[FilmingLocation] [varchar](50) NULL,
	[Moves] [varchar](50) NULL,
	[PhotosNum] [int] NULL,
	[ChStaff] [bit] NULL,
	[Lounge] [bit] NULL,
	[CorsageId] [uniqueidentifier] NULL,
	[DressIroning] [bit] NULL,
	[Kickoff] [bit] NULL,
	[StayNight] [int] NULL,
	[RoomId] [uniqueidentifier] NULL,
	[Breakfast] [bit] NULL,
	[DetailSetting] [bit] NOT NULL,
	[SpecialService] [bit] NOT NULL,
 CONSTRAINT [PK_ProductSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ProductSet] ADD  CONSTRAINT [DF_ProductSet_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_Church] FOREIGN KEY([ChurchId])
REFERENCES [dbo].[Church] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_Church]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_Currency] FOREIGN KEY([CostCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_Currency]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_Currency1] FOREIGN KEY([PriceCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_Currency1]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_DressCorsage] FOREIGN KEY([CorsageId])
REFERENCES [dbo].[DressCorsage] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_DressCorsage]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_RoomStyle] FOREIGN KEY([RoomId])
REFERENCES [dbo].[RoomStyle] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_RoomStyle]
GO
