USE [TheWe]
GO
/****** Object:  Table [dbo].[RelDressOther]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelDressOther](
	[Id] [uniqueidentifier] NOT NULL,
	[DressOtherId] [uniqueidentifier] NOT NULL,
	[DressId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RelDressOther] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RelDressOther] ADD  CONSTRAINT [DF_RelDressOther_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RelDressOther]  WITH CHECK ADD  CONSTRAINT [FK_RelDressOther_Dress] FOREIGN KEY([DressId])
REFERENCES [dbo].[Dress] ([Id])
GO
ALTER TABLE [dbo].[RelDressOther] CHECK CONSTRAINT [FK_RelDressOther_Dress]
GO
ALTER TABLE [dbo].[RelDressOther]  WITH CHECK ADD  CONSTRAINT [FK_RelDressOther_DressOther] FOREIGN KEY([DressOtherId])
REFERENCES [dbo].[DressOther] ([Id])
GO
ALTER TABLE [dbo].[RelDressOther] CHECK CONSTRAINT [FK_RelDressOther_DressOther]
GO
