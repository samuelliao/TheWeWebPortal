USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleEmployee]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleEmployee](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[EventType] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NULL,
	[EventStartTime] [datetime] NULL,
	[ColorCode] [varchar](50) NULL,
	[EventTitle] [nvarchar](max) NULL,
	[EventDescription] [nvarchar](max) NULL,
	[EventEndTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
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
ALTER TABLE [dbo].[ScheduleEmployee] ADD  CONSTRAINT [DF__ScheduleE__IsDel__5DA0D232]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ScheduleEmployee] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ScheduleEmployee] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[ScheduleEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleEmployee_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ScheduleEmployee] CHECK CONSTRAINT [FK_ScheduleEmployee_Employee]
GO
