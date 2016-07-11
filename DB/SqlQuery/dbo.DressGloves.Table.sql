USE [TheWe]
GO
/****** Object:  Table [dbo].[DressGloves]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressGloves](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](10) NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [varchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[Color] [bit] NULL,
	[Material] [bit] NULL,
	[Length] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
 CONSTRAINT [PK_Gloves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressGloves] ADD  CONSTRAINT [DF_Gloves_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressCategory]
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressStatusCode]
GO
ALTER TABLE [dbo].[DressGloves]  WITH CHECK ADD  CONSTRAINT [FK_DressGloves_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressGloves] CHECK CONSTRAINT [FK_DressGloves_DressSupplier]
GO
