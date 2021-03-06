USE [TheWe]
GO
/****** Object:  Table [dbo].[RelDressFitting]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelDressFitting](
	[Id] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NULL,
	[FittingId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_RelDressFitting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RelDressFitting] ADD  CONSTRAINT [DF_RelDressFitting_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RelDressFitting]  WITH CHECK ADD  CONSTRAINT [FK_RelDressFitting_DressFitting] FOREIGN KEY([FittingId])
REFERENCES [dbo].[DressFitting] ([Id])
GO
ALTER TABLE [dbo].[RelDressFitting] CHECK CONSTRAINT [FK_RelDressFitting_DressFitting]
GO
ALTER TABLE [dbo].[RelDressFitting]  WITH CHECK ADD  CONSTRAINT [FK_RelDressFitting_RelDressFitting] FOREIGN KEY([Id])
REFERENCES [dbo].[RelDressFitting] ([Id])
GO
ALTER TABLE [dbo].[RelDressFitting] CHECK CONSTRAINT [FK_RelDressFitting_RelDressFitting]
GO
