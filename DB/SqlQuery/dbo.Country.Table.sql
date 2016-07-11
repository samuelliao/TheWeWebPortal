USE [TheWe]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [uniqueidentifier] NOT NULL,
	[ChName] [varchar](10) NULL,
	[EngName] [varchar](50) NULL,
	[Code] [nchar](10) NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[LangCode] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Country] FOREIGN KEY([Id])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Country]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Currency]
GO
