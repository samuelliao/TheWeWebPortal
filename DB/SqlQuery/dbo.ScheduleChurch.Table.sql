USE [TheWe]
GO
/****** Object:  Table [dbo].[ScheduleChurch]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleChurch](
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [date] NOT NULL,
	[ChurchId] [uniqueidentifier] NOT NULL,
	[Description] [varchar](max) NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[AreaId] [uniqueidentifier] NOT NULL,
	[ProductSetId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ScheduleChurch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ScheduleChurch] ADD  CONSTRAINT [DF_ScheduleChurch_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ScheduleChurch]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleChurch_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[ScheduleChurch] CHECK CONSTRAINT [FK_ScheduleChurch_Area]
GO
ALTER TABLE [dbo].[ScheduleChurch]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleChurch_Church] FOREIGN KEY([ChurchId])
REFERENCES [dbo].[Church] ([Id])
GO
ALTER TABLE [dbo].[ScheduleChurch] CHECK CONSTRAINT [FK_ScheduleChurch_Church]
GO
ALTER TABLE [dbo].[ScheduleChurch]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleChurch_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[ScheduleChurch] CHECK CONSTRAINT [FK_ScheduleChurch_Country]
GO
ALTER TABLE [dbo].[ScheduleChurch]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleChurch_ProductSet] FOREIGN KEY([ProductSetId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[ScheduleChurch] CHECK CONSTRAINT [FK_ScheduleChurch_ProductSet]
GO
