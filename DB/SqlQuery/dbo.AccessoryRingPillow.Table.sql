USE [TheWe]
GO
/****** Object:  Table [dbo].[AccessoryRingPillow]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccessoryRingPillow](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_RingPillow_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[Color] [nvarchar](max) NULL,
	[Material] [nvarchar](max) NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Accessory__IsDel__2374309D]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Accessory__Updat__241E3C13]  DEFAULT (getdate()),
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAddId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_AccessoryRingPillow_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_RingPillow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AccessoryRingPillow]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryRingPillow_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[AccessoryRingPillow] CHECK CONSTRAINT [FK_AccessoryRingPillow_DressCategory]
GO
ALTER TABLE [dbo].[AccessoryRingPillow]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryRingPillow_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[AccessoryRingPillow] CHECK CONSTRAINT [FK_AccessoryRingPillow_DressStatusCode]
GO
ALTER TABLE [dbo].[AccessoryRingPillow]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryRingPillow_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[AccessoryRingPillow] CHECK CONSTRAINT [FK_AccessoryRingPillow_DressSupplier]
GO
