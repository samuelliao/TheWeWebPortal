USE [TheWe]
GO
/****** Object:  Table [dbo].[ReadMe]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReadMe](
	[TableName] [varchar](max) NULL,
	[AttrName] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[RelatedTable] [varchar](max) NULL,
	[IsTable] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
