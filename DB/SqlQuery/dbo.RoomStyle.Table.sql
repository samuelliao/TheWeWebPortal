USE [TheWe]
GO
/****** Object:  Table [dbo].[RoomStyle]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomStyle](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_RoomStyle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[RoomStyle] ADD  CONSTRAINT [DF_RoomStyle_Id]  DEFAULT (newid()) FOR [Id]
GO
