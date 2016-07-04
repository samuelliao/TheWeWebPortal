USE [TheWe]
GO
/****** Object:  Table [dbo].[ConferenceItem]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConferenceItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[ConferenceLv] [int] NOT NULL,
 CONSTRAINT [PK_ConferenceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ConferenceItem] ADD  CONSTRAINT [DF_ConferenceItem_Id]  DEFAULT (newid()) FOR [Id]
GO
