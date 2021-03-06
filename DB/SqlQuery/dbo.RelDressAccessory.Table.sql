USE [TheWe]
GO
/****** Object:  Table [dbo].[RelDressAccessory]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelDressAccessory](
	[Id] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NULL,
	[ObjectId] [uniqueidentifier] NULL,
	[Type] [nvarchar](50) NULL,
	[DressType] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RelDressAccessory] ADD  CONSTRAINT [DF__RelDressA__IsDel__5AC46587]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[RelDressAccessory] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[RelDressAccessory] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
