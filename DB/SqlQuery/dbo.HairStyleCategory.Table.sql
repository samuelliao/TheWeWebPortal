USE [TheWe]
GO
/****** Object:  Table [dbo].[HairStyleCategory]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HairStyleCategory](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_HairStyleCategory_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__HairStyle__IsDel__4B8221F7]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__HairStyle__Updat__494FC0C2]  DEFAULT (getdate()),
	[Sn] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__HairStyle__Creat__2117B236]  DEFAULT (getdate()),
 CONSTRAINT [PK_HairStyleCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
