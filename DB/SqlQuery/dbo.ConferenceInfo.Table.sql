USE [TheWe]
GO
/****** Object:  Table [dbo].[ConferenceInfo]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConferenceInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[ItemId] [uniqueidentifier] NULL,
	[OrderId] [uniqueidentifier] NULL,
	[BookingDate] [datetime] NULL,
	[IsCheck] [bit] NULL,
	[CheckTime] [datetime] NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[Remark] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_ConferenceInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ConferenceInfo] ADD  CONSTRAINT [DF_ConferenceInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ConferenceInfo] ADD  CONSTRAINT [DF_ConferenceInfo_IsCheck]  DEFAULT ((0)) FOR [IsCheck]
GO
ALTER TABLE [dbo].[ConferenceInfo] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ConferenceInfo] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ConferenceInfo] ADD  CONSTRAINT [DF_ConferenceInfo_CreatedateTime]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[ConferenceInfo]  WITH CHECK ADD  CONSTRAINT [FK_ConferenceInfo_ConferenceItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ConferenceItem] ([Id])
GO
ALTER TABLE [dbo].[ConferenceInfo] CHECK CONSTRAINT [FK_ConferenceInfo_ConferenceItem]
GO
ALTER TABLE [dbo].[ConferenceInfo]  WITH CHECK ADD  CONSTRAINT [FK_ConferenceInfo_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[ConferenceInfo] CHECK CONSTRAINT [FK_ConferenceInfo_OrderInfo]
GO
