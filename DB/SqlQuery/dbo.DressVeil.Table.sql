USE [TheWe]
GO
/****** Object:  Table [dbo].[DressVeil]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressVeil](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Color] [nvarchar](max) NULL,
	[Material] [nvarchar](max) NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[Length] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[Lace] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_Veil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressVeil] ADD  CONSTRAINT [DF_Veil_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressVeil] ADD  CONSTRAINT [DF__DressVeil__IsDel__47B19113]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressVeil] ADD  CONSTRAINT [DF__DressVeil__Updat__457F2FDE]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressVeil] ADD  CONSTRAINT [DF__DressVeil__Creat__1C52FD19]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[DressVeil]  WITH CHECK ADD  CONSTRAINT [FK_DressVeil_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressVeil] CHECK CONSTRAINT [FK_DressVeil_DressStatusCode]
GO
ALTER TABLE [dbo].[DressVeil]  WITH CHECK ADD  CONSTRAINT [FK_DressVeil_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressVeil] CHECK CONSTRAINT [FK_DressVeil_DressSupplier]
GO
ALTER TABLE [dbo].[DressVeil]  WITH CHECK ADD  CONSTRAINT [FK_DressVeil_DressVeil] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressVeil] CHECK CONSTRAINT [FK_DressVeil_DressVeil]
GO
