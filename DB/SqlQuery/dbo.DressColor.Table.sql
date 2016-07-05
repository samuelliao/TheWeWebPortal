USE [TheWe]
GO
/****** Object:  Table [dbo].[DressColor]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressColor](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](10) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_DressColor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressColor] ADD  CONSTRAINT [DF_DressColor_Id]  DEFAULT (newid()) FOR [Id]
GO
