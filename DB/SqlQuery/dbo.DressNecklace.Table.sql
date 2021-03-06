USE [TheWe]
GO
/****** Object:  Table [dbo].[DressNecklace]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressNecklace](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Color] [nvarchar](max) NULL,
	[Material] [nvarchar](max) NULL,
	[PairSn] [nvarchar](50) NULL,
	[Img] [varchar](max) NULL,
	[Number] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[PairId] [uniqueidentifier] NULL,
	[Color2] [nvarchar](max) NULL,
	[Material2] [nvarchar](max) NULL,
	[Sn] [varchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_DressNecklace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressNecklace] ADD  CONSTRAINT [DF__DressNeck__IsDel__3E2826D9]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressNecklace] ADD  CONSTRAINT [DF__DressNeck__Updat__3BF5C5A4]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressNecklace] ADD  CONSTRAINT [DF__DressNeck__Creat__11D56EA6]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressCategory2] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressCategory2]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressStatusCode]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressSupplier]
GO
