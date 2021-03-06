USE [TheWe]
GO
/****** Object:  Table [dbo].[DressClogs]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressClogs](
	[Id] [uniqueidentifier] NOT NULL,
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
	[Gender] [bit] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[PairId] [uniqueidentifier] NULL,
	[PairSn] [nvarchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_DressClogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressClogs] ADD  CONSTRAINT [DF_DressClogs_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressClogs] ADD  CONSTRAINT [DF__DressClog__IsDel__3592E0D8]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressClogs] ADD  CONSTRAINT [DF__DressClog__Updat__33607FA3]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressClogs] ADD  CONSTRAINT [DF__DressClog__Creat__0A344CDE]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[DressClogs]  WITH CHECK ADD  CONSTRAINT [FK_DressClogs_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressClogs] CHECK CONSTRAINT [FK_DressClogs_DressCategory]
GO
ALTER TABLE [dbo].[DressClogs]  WITH CHECK ADD  CONSTRAINT [FK_DressClogs_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressClogs] CHECK CONSTRAINT [FK_DressClogs_DressStatusCode]
GO
ALTER TABLE [dbo].[DressClogs]  WITH CHECK ADD  CONSTRAINT [FK_DressClogs_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressClogs] CHECK CONSTRAINT [FK_DressClogs_DressSupplier]
GO
