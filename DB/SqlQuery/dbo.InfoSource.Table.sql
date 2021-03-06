USE [TheWe]
GO
/****** Object:  Table [dbo].[InfoSource]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoSource](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_InfoSource_Id]  DEFAULT (newid()),
	[InfoId] [uniqueidentifier] NOT NULL,
	[Desciption] [nvarchar](50) NULL,
	[ConsultId] [uniqueidentifier] NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__InfoSourc__IsDel__4E5E8EA2]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_InfoSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[InfoSource]  WITH CHECK ADD  CONSTRAINT [FK_InfoSource_Consultation] FOREIGN KEY([ConsultId])
REFERENCES [dbo].[Consultation] ([Id])
GO
ALTER TABLE [dbo].[InfoSource] CHECK CONSTRAINT [FK_InfoSource_Consultation]
GO
ALTER TABLE [dbo].[InfoSource]  WITH CHECK ADD  CONSTRAINT [FK_InfoSource_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[InfoSource] CHECK CONSTRAINT [FK_InfoSource_Customer]
GO
ALTER TABLE [dbo].[InfoSource]  WITH CHECK ADD  CONSTRAINT [FK_InfoSource_InforSourceItem] FOREIGN KEY([InfoId])
REFERENCES [dbo].[InforSourceItem] ([Id])
GO
ALTER TABLE [dbo].[InfoSource] CHECK CONSTRAINT [FK_InfoSource_InforSourceItem]
GO
