USE [TheWe]
GO
/****** Object:  Table [dbo].[RoomStyle]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomStyle](
	[Id] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_RoomStyle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[RoomStyle] ADD  CONSTRAINT [DF_RoomStyle_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RoomStyle] ADD  CONSTRAINT [DF__RoomStyle__IsDel__5BB889C0]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[RoomStyle] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[RoomStyle] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
