USE [TheWe]
GO
/****** Object:  Table [dbo].[RentRecord]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentRecord](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_RentRecord_Id]  DEFAULT (newid()),
	[Category] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NOT NULL,
	[RentStartTime] [datetime] NULL,
	[RentEndTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF_RentRecord_UpdateTime]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_RentRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
