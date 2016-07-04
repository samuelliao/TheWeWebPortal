USE [TheWe]
GO
/****** Object:  Table [dbo].[ServiceItem]    Script Date: 2016/7/5 下午 12:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CategroyId] [uniqueidentifier] NOT NULL,
	[Type] [int] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Cost] [money] NULL,
	[CurrencyId] [uniqueidentifier] NULL,
	[Description] [varchar](max) NULL,
	[Sn] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ServiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ServiceItem] ADD  CONSTRAINT [DF_ServiceItem_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_Currency]
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_ServiceItemCategory] FOREIGN KEY([CategroyId])
REFERENCES [dbo].[ServiceItemCategory] ([Id])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_ServiceItemCategory]
GO
