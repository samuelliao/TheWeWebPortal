USE [TheWe]
GO
/****** Object:  Table [dbo].[DressTrailing]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressTrailing](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Trailing_Id]  DEFAULT (newid()),
	[Sn] [varchar](50) NULL,
	[Descirption] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__DressTrai__IsDel__44D52468]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__DressTrai__Updat__42A2C333]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__DressTrai__Creat__1976906E]  DEFAULT (getdate()),
 CONSTRAINT [PK_Trailing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
