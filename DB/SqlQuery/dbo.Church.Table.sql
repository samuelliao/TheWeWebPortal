USE [TheWe]
GO
/****** Object:  Table [dbo].[Church]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Church](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Church_Id]  DEFAULT (newid()),
	[Name] [nvarchar](max) NULL,
	[EngName] [nvarchar](50) NULL,
	[CountryId] [uniqueidentifier] NULL,
	[AreaId] [uniqueidentifier] NULL,
	[MealImg] [varchar](max) NULL,
	[MapImg] [varchar](max) NULL,
	[DmImg] [varchar](max) NULL,
	[Img] [varchar](max) NULL,
	[Capacities] [int] NULL,
	[Price] [money] NULL,
	[Remark] [nvarchar](max) NULL,
	[CnName] [nvarchar](max) NULL,
	[JpName] [nvarchar](max) NULL,
	[isDelete] [bit] NULL CONSTRAINT [DF__Church__isDelete__26509D48]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Church__UpdateTi__26FAA8BE]  DEFAULT (getdate()),
	[PatioHeight] [int] NULL,
	[RedCarpetLong] [int] NULL,
	[RedCarpetCategory] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Sn] [varchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_Church_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Church] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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
