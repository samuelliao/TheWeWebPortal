USE [TheWe]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [uniqueidentifier] NOT NULL,
	[ChName] [varchar](10) NULL,
	[EngName] [varchar](50) NULL,
	[Code] [varchar](3) NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Area] ADD  CONSTRAINT [DF_City_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_City_Country]
GO
