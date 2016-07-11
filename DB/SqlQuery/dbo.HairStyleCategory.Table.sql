USE [TheWe]
GO
/****** Object:  Table [dbo].[HairStyleCategory]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HairStyleCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [uniqueidentifier] NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_HairStyleCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[HairStyleCategory] ADD  CONSTRAINT [DF_HairStyleCategory_Id]  DEFAULT (newid()) FOR [Id]
GO
