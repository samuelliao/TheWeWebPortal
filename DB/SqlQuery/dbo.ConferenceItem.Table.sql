USE [TheWe]
GO
/****** Object:  Table [dbo].[ConferenceItem]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConferenceItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ConferenceItem_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ConferenceLv] [int] NOT NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Conferenc__IsDel__2838E5BA]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Conferenc__Updat__28E2F130]  DEFAULT (getdate()),
	[Sn] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_ConferenceItem_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_ConferenceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
