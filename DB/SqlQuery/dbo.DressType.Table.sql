USE [TheWe]
GO
/****** Object:  Table [dbo].[DressType]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressType](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_DressType_Id]  DEFAULT (newid()),
	[Sn] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressType__IsDel__45C948A1]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressType__Updat__4396E76C]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressType__Creat__1A6AB4A7]  DEFAULT (getdate()),
 CONSTRAINT [PK_DressType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
