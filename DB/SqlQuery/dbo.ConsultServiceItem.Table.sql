USE [TheWe]
GO
/****** Object:  Table [dbo].[ConsultServiceItem]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultServiceItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ConsultServiceItem_Id]  DEFAULT (newid()),
	[ConsultId] [uniqueidentifier] NOT NULL,
	[ServiceCategoryId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__ConsultSe__IsDel__2B155265]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[Lv] [int] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_ConsultServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

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
