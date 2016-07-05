USE [TheWe]
GO
/****** Object:  Table [dbo].[InfoSource]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InfoSource](
	[Id] [uniqueidentifier] NOT NULL,
	[InfoId] [uniqueidentifier] NOT NULL,
	[Desciption] [varchar](50) NULL,
	[ConsultId] [uniqueidentifier] NULL,
	[CustomerId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_InfoSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[InfoSource] ADD  CONSTRAINT [DF_InfoSource_Id]  DEFAULT (newid()) FOR [Id]
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
