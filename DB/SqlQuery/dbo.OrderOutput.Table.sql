USE [TheWe]
GO
/****** Object:  Table [dbo].[OrderOutput]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderOutput](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[OrderId] [uniqueidentifier] NULL,
	[DressImg] [varchar](max) NULL,
	[HairStyleImg] [varchar](max) NULL,
	[AccessoryImg] [varchar](max) NULL,
	[GroomSuit] [varchar](max) NULL,
	[GroomAccessory] [varchar](max) NULL,
	[BouquetImg] [varchar](max) NULL,
	[LangType] [varchar](50) NULL,
	[DressDesc] [nvarchar](max) NULL,
	[HairStyleDesc] [nvarchar](max) NULL,
	[AccessoryDesc] [nvarchar](max) NULL,
	[GroomSuitDesc] [nvarchar](max) NULL,
	[GroomAccessoryDesc] [nvarchar](max) NULL,
	[BouquetDesc] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_OrderOutput] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrderOutput] ADD  CONSTRAINT [DF_OrderOutput_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[OrderOutput] ADD  CONSTRAINT [DF__OrderOutp__IsDel__513AFB4D]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[OrderOutput] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[OrderOutput] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[OrderOutput]  WITH CHECK ADD  CONSTRAINT [FK_OrderOutput_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[OrderOutput] CHECK CONSTRAINT [FK_OrderOutput_OrderInfo]
GO
