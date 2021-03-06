USE [TheWe]
GO
/****** Object:  Table [dbo].[PermissonGroup]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissonGroup](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[GroupId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_PermissonGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PermissonGroup] ADD  CONSTRAINT [DF_PermissonGroup_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PermissonGroup] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[PermissonGroup] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[PermissonGroup] ADD  DEFAULT (getdate()) FOR [CreatedateTime]
GO
