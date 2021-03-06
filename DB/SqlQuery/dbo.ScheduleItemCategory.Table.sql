USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleItemCategory]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleItemCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ScheduleItemCategory] ADD  CONSTRAINT [DF__ScheduleI__IsDel__5F891AA4]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ScheduleItemCategory] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ScheduleItemCategory] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
