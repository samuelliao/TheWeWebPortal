USE [TheWe]
GO
/****** Object:  Table [dbo].[DressHeadwear]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressHeadwear](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_DressHeadwear_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](50) NULL,
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
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressHead__IsDel__3B4BBA2E]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressHead__Updat__391958F9]  DEFAULT (getdate()),
	[StoreId] [uniqueidentifier] NULL,
	[Color2] [nvarchar](max) NULL,
	[Material2] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressHead__Creat__0EF901FB]  DEFAULT (getdate()),
 CONSTRAINT [PK_DressHeadwear] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressHeadwear]  WITH CHECK ADD  CONSTRAINT [FK_DressHeadwear_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressHeadwear] CHECK CONSTRAINT [FK_DressHeadwear_DressCategory]
GO
ALTER TABLE [dbo].[DressHeadwear]  WITH CHECK ADD  CONSTRAINT [FK_DressHeadwear_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressHeadwear] CHECK CONSTRAINT [FK_DressHeadwear_DressStatusCode]
GO
ALTER TABLE [dbo].[DressHeadwear]  WITH CHECK ADD  CONSTRAINT [FK_DressHeadwear_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressHeadwear] CHECK CONSTRAINT [FK_DressHeadwear_DressSupplier]
GO
