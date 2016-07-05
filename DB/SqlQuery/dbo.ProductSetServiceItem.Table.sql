USE [TheWe]
GO
/****** Object:  Table [dbo].[ProductSetServiceItem]    Script Date: 2016/7/5 下午 12:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSetServiceItem](
	[Id] [uniqueidentifier] NOT NULL,
	[SetId] [uniqueidentifier] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[UnitId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProductSetServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ProductSetServiceItem] ADD  CONSTRAINT [DF_ProductSetServiceItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ProductSetServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSetServiceItem_ItemUnit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[ItemUnit] ([Id])
GO
ALTER TABLE [dbo].[ProductSetServiceItem] CHECK CONSTRAINT [FK_ProductSetServiceItem_ItemUnit]
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
