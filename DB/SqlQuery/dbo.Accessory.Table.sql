USE [TheWe]
GO
/****** Object:  Table [dbo].[Accessory]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accessory](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Img] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
