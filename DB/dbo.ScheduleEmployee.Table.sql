USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleEmployee]    Script Date: 2016/7/4 下午 04:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleEmployee](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[Description] [varchar](max) NULL,
	[EventType] [int] NOT NULL,
	[EventId] [uniqueidentifier] NULL,
	[EventTime] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ScheduleEmployee] ADD  CONSTRAINT [DF_Table_1_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ScheduleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleEmployee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ScheduleEmployee] CHECK CONSTRAINT [FK_ScheduleEmployee_Employee]
GO
