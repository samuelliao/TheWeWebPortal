USE [TheWe]
GO
/****** Object:  Table [dbo].[ConsultOverseaWedding]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultOverseaWedding](
	[Id] [uniqueidentifier] NOT NULL,
	[ChurchId] [uniqueidentifier] NOT NULL,
	[AreaId] [uniqueidentifier] NOT NULL,
	[ConsultId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ConsultOverseaWedding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConsultOverseaWedding] ADD  CONSTRAINT [DF_ConsultOverseaWedding_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ConsultOverseaWedding]  WITH CHECK ADD  CONSTRAINT [FK_ConsultOverseaWedding_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[ConsultOverseaWedding] CHECK CONSTRAINT [FK_ConsultOverseaWedding_Area]
GO
ALTER TABLE [dbo].[ConsultOverseaWedding]  WITH CHECK ADD  CONSTRAINT [FK_ConsultOverseaWedding_Church] FOREIGN KEY([ChurchId])
REFERENCES [dbo].[Church] ([Id])
GO
ALTER TABLE [dbo].[ConsultOverseaWedding] CHECK CONSTRAINT [FK_ConsultOverseaWedding_Church]
GO
ALTER TABLE [dbo].[ConsultOverseaWedding]  WITH CHECK ADD  CONSTRAINT [FK_ConsultOverseaWedding_Consultation] FOREIGN KEY([ConsultId])
REFERENCES [dbo].[Consultation] ([Id])
GO
ALTER TABLE [dbo].[ConsultOverseaWedding] CHECK CONSTRAINT [FK_ConsultOverseaWedding_Consultation]
GO
