USE [TheWe]
GO
/****** Object:  Table [dbo].[PermissionItem]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermissionItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_PermissionItem_Id]  DEFAULT (newid()),
	[ObjectId] [uniqueidentifier] NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
	[CanEntry] [bit] NOT NULL CONSTRAINT [DF_PermissionItem_CanEntry]  DEFAULT ((0)),
	[CanCreate] [bit] NOT NULL CONSTRAINT [DF_PermissionItem_CanCreate]  DEFAULT ((0)),
	[CanModify] [bit] NOT NULL CONSTRAINT [DF_PermissionItem_CanModify]  DEFAULT ((0)),
	[CanDelete] [bit] NOT NULL CONSTRAINT [DF_PermissionItem_CanDelete]  DEFAULT ((0)),
	[CanExport] [bit] NOT NULL CONSTRAINT [DF_PermissionItem_CanExport]  DEFAULT ((0)),
	[Type] [varchar](50) NULL,
	[IsDelete] [bit] NULL DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[ObjectSn] [nvarchar](50) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_PermissionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PermissionItem]  WITH CHECK ADD  CONSTRAINT [FK_PermissionItem_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[PermissionItem] CHECK CONSTRAINT [FK_PermissionItem_Permission]
GO
