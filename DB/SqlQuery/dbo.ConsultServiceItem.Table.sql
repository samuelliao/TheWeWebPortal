USE [TheWe]
GO
/****** Object:  Table [dbo].[ConsultServiceItem]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConsultServiceItem](
	[Id] [uniqueidentifier] NOT NULL,
	[ConsultId] [uniqueidentifier] NOT NULL,
	[ServiceCategoryId] [uniqueidentifier] NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_ConsultServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ConsultServiceItem] ADD  CONSTRAINT [DF_ConsultServiceItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ConsultServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ConsultServiceItem_Consultation] FOREIGN KEY([ConsultId])
REFERENCES [dbo].[Consultation] ([Id])
GO
ALTER TABLE [dbo].[ConsultServiceItem] CHECK CONSTRAINT [FK_ConsultServiceItem_Consultation]
GO
ALTER TABLE [dbo].[ConsultServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ConsultServiceItem_ServiceItemCategory] FOREIGN KEY([ServiceCategoryId])
REFERENCES [dbo].[ServiceItemCategory] ([Id])
GO
ALTER TABLE [dbo].[ConsultServiceItem] CHECK CONSTRAINT [FK_ConsultServiceItem_ServiceItemCategory]
GO
