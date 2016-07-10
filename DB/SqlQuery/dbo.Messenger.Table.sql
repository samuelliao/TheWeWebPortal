USE [TheWe]
GO
/****** Object:  Table [dbo].[Messenger]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Messenger](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](10) NULL,
	[Descirption] [varchar](50) NULL,
 CONSTRAINT [PK_Messenger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Messenger] ADD  CONSTRAINT [DF_Messenger_Id]  DEFAULT (newid()) FOR [Id]
GO
