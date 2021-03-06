USE [TheWe]
GO
/****** Object:  Table [dbo].[WeddingPhotoLocation]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeddingPhotoLocation](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[CountryId] [uniqueidentifier] NULL,
	[AreaId] [uniqueidentifier] NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_WeddingPhotographyItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WeddingPhotoLocation] ADD  CONSTRAINT [DF_WeddingPhotographyItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[WeddingPhotoLocation]  WITH CHECK ADD  CONSTRAINT [FK_WeddingPhotoLocation_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[WeddingPhotoLocation] CHECK CONSTRAINT [FK_WeddingPhotoLocation_Area]
GO
ALTER TABLE [dbo].[WeddingPhotoLocation]  WITH CHECK ADD  CONSTRAINT [FK_WeddingPhotoLocation_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[WeddingPhotoLocation] CHECK CONSTRAINT [FK_WeddingPhotoLocation_Country]
GO
