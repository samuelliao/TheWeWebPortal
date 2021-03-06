USE [TheWe]
GO
/****** Object:  Table [dbo].[FunctionItem]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_FunctionItem_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__FunctionI__IsDel__4A8DFDBE]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_FunctionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
