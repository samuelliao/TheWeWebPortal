USE [TheWe]
GO
/****** Object:  Table [dbo].[PermissonGroup]    Script Date: 2016/7/11 下午 02:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissonGroup](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[GroupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PermissonGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PermissonGroup] ADD  CONSTRAINT [DF_PermissonGroup_Id]  DEFAULT (newid()) FOR [Id]
GO
