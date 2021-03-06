USE [TheWe]
GO
/****** Object:  Table [dbo].[ProductSet]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ProductSet_Id]  DEFAULT (newid()),
	[CountryId] [uniqueidentifier] NULL,
	[Decoration] [nvarchar](max) NULL,
	[Performence] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[PriceCurrencyId] [uniqueidentifier] NULL,
	[Cost] [money] NULL,
	[CostCurrencyId] [uniqueidentifier] NULL,
	[ChurchId] [uniqueidentifier] NULL,
	[DmImg] [varchar](max) NULL,
	[ChurchCost] [bit] NULL CONSTRAINT [DF_ProductSet_ChurchCost]  DEFAULT ((0)),
	[Pastor] [bit] NULL CONSTRAINT [DF_ProductSet_Pastor]  DEFAULT ((0)),
	[Certificate] [bit] NULL CONSTRAINT [DF_ProductSet_Certificate]  DEFAULT ((0)),
	[RingPillow] [bit] NULL CONSTRAINT [DF_ProductSet_RingPillow]  DEFAULT ((0)),
	[SignPen] [bit] NULL CONSTRAINT [DF_ProductSet_SignPen]  DEFAULT ((0)),
	[BridalMakeup] [nvarchar](max) NULL,
	[GroomMakeup] [nvarchar](max) NULL,
	[WeddingFilmingTime] [nvarchar](max) NULL,
	[OtherFilmingTime] [nvarchar](max) NULL,
	[FilmingLocation] [nvarchar](max) NULL,
	[Moves] [nvarchar](max) NULL,
	[PhotosNum] [int] NULL,
	[Staff] [int] NULL,
	[Lounge] [bit] NULL CONSTRAINT [DF_ProductSet_Lounge]  DEFAULT ((0)),
	[CorsageId] [uniqueidentifier] NULL,
	[DressIroning] [bit] NULL CONSTRAINT [DF_ProductSet_DressIroning]  DEFAULT ((0)),
	[Kickoff] [bit] NULL CONSTRAINT [DF_ProductSet_Kickoff]  DEFAULT ((0)),
	[StayNight] [int] NULL,
	[RoomId] [nvarchar](50) NULL,
	[Breakfast] [bit] NULL CONSTRAINT [DF_ProductSet_Breakfast]  DEFAULT ((0)),
	[IsDelete] [bit] NULL CONSTRAINT [DF__ProductSe__IsDel__58DC1D15]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__ProductSe__Updat__579DE019]  DEFAULT (getdate()),
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[Category] [uniqueidentifier] NULL,
	[Lunch] [bit] NULL CONSTRAINT [DF_ProductSet_Lunch]  DEFAULT ((0)),
	[Dinner] [bit] NULL CONSTRAINT [DF_ProductSet_Dinner]  DEFAULT ((0)),
	[Rehearsal] [bit] NULL CONSTRAINT [DF_ProductSet_Rehearsal]  DEFAULT ((0)),
	[WeddingCategory] [uniqueidentifier] NULL,
	[AreaId] [uniqueidentifier] NULL,
	[IsLegal] [bit] NULL CONSTRAINT [DF_ProductSet_IsLegal]  DEFAULT ((0)),
	[Corsage] [nvarchar](max) NULL,
	[Sn] [varchar](50) NULL,
	[BaseId] [uniqueidentifier] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_ProductSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
