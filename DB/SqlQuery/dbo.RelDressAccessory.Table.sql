USE [TheWe]
GO
/****** Object:  Table [dbo].[RelDressAccessory]    Script Date: 2016/7/11 下午 02:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RelDressAccessory](
	[Id] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NULL,
	[ObjectId] [uniqueidentifier] NULL,
	[Type] [varchar](50) NULL,
	[DressType] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
