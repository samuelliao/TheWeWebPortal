USE [TheWe]
GO
/****** Object:  Table [dbo].[AccessoryOther]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccessoryOther](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_AccessoryOther_Id]  DEFAULT (newid()),
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
	[Length] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Accessory__IsDel__22800C64]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Accessory__Updat__232A17DA]  DEFAULT (getdate()),
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_AccessoryOther_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_AccessoryOther] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AccessoryOther]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryOther_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[AccessoryOther] CHECK CONSTRAINT [FK_AccessoryOther_DressCategory]
GO
ALTER TABLE [dbo].[AccessoryOther]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryOther_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[AccessoryOther] CHECK CONSTRAINT [FK_AccessoryOther_DressStatusCode]
GO
