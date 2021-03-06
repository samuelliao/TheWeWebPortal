USE [TheWe]
GO
/****** Object:  Table [dbo].[DressCorsage]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressCorsage](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[Img] [varchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_Corsage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressCorsage] ADD  CONSTRAINT [DF_Corsage_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressCorsage] ADD  CONSTRAINT [DF__DressCors__IsDel__377B294A]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressCorsage] ADD  CONSTRAINT [DF__DressCors__Updat__3548C815]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressCorsage] ADD  CONSTRAINT [DF_DressCorsage_Img]  DEFAULT ('DressCorsage\'+[dbo].[GetDressCorsageSn]()) FOR [Img]
GO
ALTER TABLE [dbo].[DressCorsage] ADD  CONSTRAINT [DF__DressCors__Creat__0C1C9550]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
