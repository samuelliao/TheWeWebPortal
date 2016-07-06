USE [TheWe]
GO
/****** Object:  Table [dbo].[PermissionItem]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionItem](
	[Id] [uniqueidentifier] NOT NULL,
	[FunctionId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
	[CanEntry] [bit] NOT NULL,
	[CanCreate] [bit] NOT NULL,
	[CanModify] [bit] NOT NULL,
	[CanDelete] [bit] NOT NULL,
	[CanExport] [bit] NOT NULL,
 CONSTRAINT [PK_PermissionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_CanEntry]  DEFAULT ((0)) FOR [CanEntry]
GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_CanCreate]  DEFAULT ((0)) FOR [CanCreate]
GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_CanModify]  DEFAULT ((0)) FOR [CanModify]
GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_CanDelete]  DEFAULT ((0)) FOR [CanDelete]
GO
ALTER TABLE [dbo].[PermissionItem] ADD  CONSTRAINT [DF_PermissionItem_CanExport]  DEFAULT ((0)) FOR [CanExport]
GO
ALTER TABLE [dbo].[PermissionItem]  WITH CHECK ADD  CONSTRAINT [FK_PermissionItem_FunctionItem] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[FunctionItem] ([Id])
GO
ALTER TABLE [dbo].[PermissionItem] CHECK CONSTRAINT [FK_PermissionItem_FunctionItem]
GO
ALTER TABLE [dbo].[PermissionItem]  WITH CHECK ADD  CONSTRAINT [FK_PermissionItem_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[PermissionItem] CHECK CONSTRAINT [FK_PermissionItem_Permission]
GO
