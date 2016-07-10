USE [TheWe]
GO
/****** Object:  Table [dbo].[DressSupplier]    Script Date: 2016/7/10 下午 06:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressSupplier](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](10) NULL,
	[Descirption] [varchar](50) NULL,
	[Country] [uniqueidentifier] NULL,
	[City] [uniqueidentifier] NULL,
	[IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF_Supplier_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF_DressSupplier_IsValid]  DEFAULT ((1)) FOR [IsValid]
GO
ALTER TABLE [dbo].[DressSupplier]  WITH CHECK ADD  CONSTRAINT [FK_DressSupplier_City] FOREIGN KEY([City])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[DressSupplier] CHECK CONSTRAINT [FK_DressSupplier_City]
GO
ALTER TABLE [dbo].[DressSupplier]  WITH CHECK ADD  CONSTRAINT [FK_DressSupplier_Country] FOREIGN KEY([Country])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[DressSupplier] CHECK CONSTRAINT [FK_DressSupplier_Country]
GO
