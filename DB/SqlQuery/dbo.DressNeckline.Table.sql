USE [TheWe]
GO
/****** Object:  Table [dbo].[DressNeckline]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressNeckline](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Neckline_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[Descirption] [varchar](max) NULL,
	[Name] [varchar](50) NULL,
	[EngName] [varchar](50) NULL,
	[JpName] [varchar](50) NULL,
	[CnName] [varchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressNeck__IsDel__3F1C4B12]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressNeck__Updat__3CE9E9DD]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressNeck__Creat__12C992DF]  DEFAULT (getdate()),
 CONSTRAINT [PK_Neckline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
