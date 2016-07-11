USE [TheWe]
GO
/****** Object:  Table [dbo].[RentRecord]    Script Date: 2016/7/11 下午 02:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentRecord](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NOT NULL,
	[RentStartTime] [datetime] NULL,
	[RentEndTime] [datetime] NULL
) ON [PRIMARY]

GO
