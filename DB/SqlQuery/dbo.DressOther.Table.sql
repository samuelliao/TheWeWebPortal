USE [TheWe]
GO
/****** Object:  Table [dbo].[DressOther]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressOther](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_DressOther] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[DressOther] ADD  CONSTRAINT [DF_DressOther_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressOther] ADD  CONSTRAINT [DF__DressOthe__IsDel__40106F4B]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressOther] ADD  CONSTRAINT [DF__DressOthe__Updat__3DDE0E16]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressOther] ADD  CONSTRAINT [DF__DressOthe__Creat__14B1DB51]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
