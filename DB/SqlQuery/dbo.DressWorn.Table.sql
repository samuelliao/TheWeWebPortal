USE [TheWe]
GO
/****** Object:  Table [dbo].[DressWorn]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressWorn](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Worn_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[Descirption] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressWorn__IsDel__48A5B54C]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressWorn__Updat__46735417]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressWorn__Creat__1D472152]  DEFAULT (getdate()),
 CONSTRAINT [PK_Worn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
