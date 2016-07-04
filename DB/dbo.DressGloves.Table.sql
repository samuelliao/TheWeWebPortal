USE [TheWe]
GO
/****** Object:  Table [dbo].[DressGloves]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressGloves](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](10) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Gloves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressGloves] ADD  CONSTRAINT [DF_Gloves_Id]  DEFAULT (newid()) FOR [Id]
GO
