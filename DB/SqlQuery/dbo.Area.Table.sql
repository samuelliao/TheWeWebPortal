USE [TheWe]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_City_Id]  DEFAULT (newid()),
	[Name] [nvarchar](max) NULL,
	[EngName] [nvarchar](50) NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Area__IsDelete__255C790F]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_Area_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_City_Country]
GO
