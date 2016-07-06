USE [TheWe]
GO
/****** Object:  Table [dbo].[Church]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Church](
	[Id] [uniqueidentifier] NOT NULL,
	[ChName] [varchar](10) NOT NULL,
	[EnName] [varchar](50) NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[AreaId] [uniqueidentifier] NULL,
	[MealImg] [varchar](50) NULL,
	[MapImg] [varchar](50) NULL,
	[DmImg] [varchar](50) NULL,
	[PhotoImg] [varchar](50) NULL,
	[Capacities] [int] NULL,
	[Price] [money] NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_Church] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Church] ADD  CONSTRAINT [DF_Church_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Church]  WITH CHECK ADD  CONSTRAINT [FK_Church_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Church] CHECK CONSTRAINT [FK_Church_Area]
GO
ALTER TABLE [dbo].[Church]  WITH CHECK ADD  CONSTRAINT [FK_Church_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Church] CHECK CONSTRAINT [FK_Church_Country]
GO
