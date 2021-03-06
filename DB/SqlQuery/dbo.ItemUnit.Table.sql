USE [TheWe]
GO
/****** Object:  Table [dbo].[ItemUnit]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemUnit](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ItemUnit_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__ItemUnit__IsDele__4F52B2DB]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_ItemUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
