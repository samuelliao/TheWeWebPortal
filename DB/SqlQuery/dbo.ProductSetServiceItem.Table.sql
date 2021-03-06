USE [TheWe]
GO
/****** Object:  Table [dbo].[ProductSetServiceItem]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSetServiceItem](
	[Id] [uniqueidentifier] NOT NULL,
	[SetId] [uniqueidentifier] NULL,
	[ItemId] [uniqueidentifier] NULL,
	[Number] [int] NULL,
	[UnitId] [uniqueidentifier] NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[OrderId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[Price] [money] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_ProductSetServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProductSetServiceItem] ADD  CONSTRAINT [DF_ProductSetServiceItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ProductSetServiceItem] ADD  CONSTRAINT [DF__ProductSe__IsDel__59D0414E]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ProductSetServiceItem] ADD  CONSTRAINT [DF__ProductSe__Updat__58920452]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ProductSetServiceItem] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_ItemUnit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[ItemUnit] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_ItemUnit]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_OrderInfo]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_ProductSet] FOREIGN KEY([SetId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_ProductSet]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_ServiceItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ServiceItem] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_ServiceItem]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_ServiceItemCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ServiceItemCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_ServiceItemCategory]
GO
