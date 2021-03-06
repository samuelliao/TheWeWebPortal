USE [TheWe]
GO
/****** Object:  Table [dbo].[DressBack]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressBack](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Back_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[Descirption] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressBack__IsDel__31C24FF4]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressBack__Updat__2F8FEEBF]  DEFAULT (getdate()),
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressBack__Creat__0663BBFA]  DEFAULT (getdate()),
 CONSTRAINT [PK_Back] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
