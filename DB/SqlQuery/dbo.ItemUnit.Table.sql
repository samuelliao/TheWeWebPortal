USE [TheWe]
GO
/****** Object:  Table [dbo].[ItemUnit]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemUnit](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_ItemUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ItemUnit] ADD  CONSTRAINT [DF_ItemUnit_Id]  DEFAULT (newid()) FOR [Id]
GO
