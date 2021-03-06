USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleEventDetail]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleEventDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[ScheduleId] [uniqueidentifier] NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[StackHolderId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_ScheduleEventDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ScheduleEventDetail] ADD  CONSTRAINT [DF_ScheduleEventDetail_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ScheduleEventDetail] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ScheduleEventDetail] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ScheduleEventDetail] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
