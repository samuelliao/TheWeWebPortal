USE [TheWe]
GO
/****** Object:  Table [dbo].[DressEarring]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressEarring](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_DressEarring_Id]  DEFAULT (newid()),
	[Sn] [varchar](50) NULL,
	[Color] [nvarchar](max) NULL,
	[Material] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[Worn] [bit] NULL,
	[PairSn] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressEarr__IsDel__386F4D83]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressEarr__Updat__363CEC4E]  DEFAULT (getdate()),
	[StoreId] [uniqueidentifier] NULL,
	[Color2] [nvarchar](max) NULL,
	[Material2] [nvarchar](max) NULL,
	[PairId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_DressEarring] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressCategory1] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressCategory1]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressStatusCode]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressSupplier]
GO
