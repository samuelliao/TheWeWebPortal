USE [TheWe]
GO
/****** Object:  Table [dbo].[ConsultWeddingLocoation]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultWeddingLocoation](
	[Id] [uniqueidentifier] NOT NULL,
	[ConsultId] [uniqueidentifier] NOT NULL,
	[ChurchId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ConsultWedding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConsultWeddingLocoation] ADD  CONSTRAINT [DF_ConsultWedding_Id]  DEFAULT (newid()) FOR [Id]
GO
