USE [TheWe]
GO
/****** Object:  Table [dbo].[Messenger]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messenger](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Messenger_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NULL,
	[Descirption] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF_Messenger_IsDelete]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Messenger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
