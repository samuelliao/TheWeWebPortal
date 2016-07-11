USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleEventDetail]    Script Date: 2016/7/11 下午 02:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleEventDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[ScheduleId] [uniqueidentifier] NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[StackHolderId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ScheduleEventDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ScheduleEventDetail] ADD  CONSTRAINT [DF_ScheduleEventDetail_Id]  DEFAULT (newid()) FOR [Id]
GO
