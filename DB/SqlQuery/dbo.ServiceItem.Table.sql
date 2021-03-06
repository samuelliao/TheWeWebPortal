USE [TheWe]
GO
/****** Object:  Table [dbo].[ServiceItem]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ServiceItem_Id]  DEFAULT (newid()),
	[Sn] [varchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [uniqueidentifier] NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Cost] [money] NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[Price] [money] NULL,
	[CnName] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__ServiceIt__IsDel__607D3EDD]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__ServiceIt__Updat__5F3F01E1]  DEFAULT (getdate()),
	[IsGeneral] [bit] NULL,
	[Img] [varchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__ServiceIt__Creat__38EF3BC7]  DEFAULT (getdate()),
 CONSTRAINT [PK_ServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_ServiceItem] FOREIGN KEY([Id])
REFERENCES [dbo].[ServiceItem] ([Id])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_ServiceItem]
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_ServiceItemCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ServiceItemCategory] ([Id])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_ServiceItemCategory]
GO
