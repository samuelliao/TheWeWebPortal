USE [TheWe]
GO
/****** Object:  Table [dbo].[DressFitting]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressFitting](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](10) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Fitting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressFitting] ADD  CONSTRAINT [DF_Fitting_Id]  DEFAULT (newid()) FOR [Id]
GO
