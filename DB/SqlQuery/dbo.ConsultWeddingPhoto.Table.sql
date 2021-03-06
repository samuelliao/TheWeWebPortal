USE [TheWe]
GO
/****** Object:  Table [dbo].[ConsultWeddingPhoto]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultWeddingPhoto](
	[Id] [uniqueidentifier] NOT NULL,
	[LocationId] [uniqueidentifier] NOT NULL,
	[ConsultId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ConsultWeddingPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConsultWeddingPhoto]  WITH CHECK ADD  CONSTRAINT [FK_ConsultWeddingPhoto_Consultation] FOREIGN KEY([ConsultId])
REFERENCES [dbo].[Consultation] ([Id])
GO
ALTER TABLE [dbo].[ConsultWeddingPhoto] CHECK CONSTRAINT [FK_ConsultWeddingPhoto_Consultation]
GO
ALTER TABLE [dbo].[ConsultWeddingPhoto]  WITH CHECK ADD  CONSTRAINT [FK_ConsultWeddingPhoto_WeddingPhotoConsultation] FOREIGN KEY([LocationId])
REFERENCES [dbo].[WeddingPhotoConsultation] ([Id])
GO
ALTER TABLE [dbo].[ConsultWeddingPhoto] CHECK CONSTRAINT [FK_ConsultWeddingPhoto_WeddingPhotoConsultation]
GO
