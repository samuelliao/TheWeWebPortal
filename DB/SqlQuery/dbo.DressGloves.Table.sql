USE [TheWe]
GO
/****** Object:  Table [dbo].[DressGloves]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressGloves](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Gloves_Id]  DEFAULT (newid()),
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
	[Length] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressGlov__IsDel__3A5795F5]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressGlov__Updat__382534C0]  DEFAULT (getdate()),
	[StoreId] [uniqueidentifier] NULL,
	[Gender] [bit] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressGlov__Creat__13BDB718]  DEFAULT (getdate()),
 CONSTRAINT [PK_Gloves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressCategory]
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressStatusCode]
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressSupplier]
GO
