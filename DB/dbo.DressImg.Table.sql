USE [TheWe]
GO
/****** Object:  Table [dbo].[DressImg]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressImg](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [uniqueidentifier] NOT NULL,
	[DataSeq] [nchar](10) NULL,
	[Description] [varchar](50) NULL,
	[ImgId] [varchar](50) NULL,
 CONSTRAINT [PK_DressImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressImg] ADD  CONSTRAINT [DF_DressImg_Id]  DEFAULT (newid()) FOR [Id]
GO
