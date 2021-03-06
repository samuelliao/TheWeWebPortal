USE [TheWe]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Country_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[Code] [nchar](10) NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[LangCode] [int] NULL,
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Country__IsDelet__2DF1BF10]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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
