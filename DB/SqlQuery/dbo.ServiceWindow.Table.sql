USE [TheWe]
GO
/****** Object:  Table [dbo].[ServiceWindow]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceWindow](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_ServiceWindow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ServiceWindow] ADD  CONSTRAINT [DF_ServiceWindow_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ServiceWindow] ADD  CONSTRAINT [DF__ServiceWi__IsDel__2097C3F2]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ServiceWindow] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ServiceWindow] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[ServiceWindow]  WITH CHECK ADD  CONSTRAINT [FK_ServiceWindow_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[ServiceWindow] CHECK CONSTRAINT [FK_ServiceWindow_Country]
GO
