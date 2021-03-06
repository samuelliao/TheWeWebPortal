USE [TheWe]
GO
/****** Object:  Table [dbo].[PerformList]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformList](
	[Id] [uniqueidentifier] NOT NULL,
	[StaffId] [uniqueidentifier] NOT NULL,
	[ProductSetId] [uniqueidentifier] NULL,
	[ChruchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PerformList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformList] ADD  CONSTRAINT [DF_PerformList_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PerformList]  WITH CHECK ADD  CONSTRAINT [FK_PerformList_Church] FOREIGN KEY([ChruchId])
REFERENCES [dbo].[Church] ([Id])
GO
ALTER TABLE [dbo].[PerformList] CHECK CONSTRAINT [FK_PerformList_Church]
GO
ALTER TABLE [dbo].[PerformList]  WITH CHECK ADD  CONSTRAINT [FK_PerformList_PerformItem] FOREIGN KEY([StaffId])
REFERENCES [dbo].[PerformItem] ([Id])
GO
ALTER TABLE [dbo].[PerformList] CHECK CONSTRAINT [FK_PerformList_PerformItem]
GO
ALTER TABLE [dbo].[PerformList]  WITH CHECK ADD  CONSTRAINT [FK_PerformList_ProductSet] FOREIGN KEY([ProductSetId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[PerformList] CHECK CONSTRAINT [FK_PerformList_ProductSet]
GO
