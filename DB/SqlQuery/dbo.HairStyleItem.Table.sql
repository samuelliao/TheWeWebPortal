USE [TheWe]
GO
/****** Object:  Table [dbo].[HairStyleItem]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HairStyleItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Type] [uniqueidentifier] NULL,
	[Img] [varchar](max) NULL,
 CONSTRAINT [PK_HairStyleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[HairStyleItem] ADD  CONSTRAINT [DF_HairStyleItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[HairStyleItem]  WITH CHECK ADD  CONSTRAINT [FK_HairStyleItem_HairStyleCategory] FOREIGN KEY([Type])
REFERENCES [dbo].[HairStyleCategory] ([Id])
GO
ALTER TABLE [dbo].[HairStyleItem] CHECK CONSTRAINT [FK_HairStyleItem_HairStyleCategory]
GO
