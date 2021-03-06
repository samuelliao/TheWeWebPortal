USE [TheWe]
GO
/****** Object:  Table [dbo].[PerformItem]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerformItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [varchar](50) NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_PerformItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PerformItem] ADD  CONSTRAINT [DF_PerformItem_Id]  DEFAULT (newid()) FOR [Id]
GO
