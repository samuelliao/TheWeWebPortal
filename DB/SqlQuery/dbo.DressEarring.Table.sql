USE [TheWe]
GO
/****** Object:  Table [dbo].[DressEarring]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressEarring](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Color] [bit] NULL,
	[Material] [bit] NULL,
	[Type] [uniqueidentifier] NULL,
	[Worn] [bit] NULL,
	[Necklace] [bit] NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [varchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
 CONSTRAINT [PK_DressEarring] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressEarring] ADD  CONSTRAINT [DF_DressEarring_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressCategory] FOREIGN KEY([Type])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressCategory]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressCategory1] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressCategory1]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressStatusCode]
GO
ALTER TABLE [dbo].[DressEarring]  WITH CHECK ADD  CONSTRAINT [FK_DressEarring_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressEarring] CHECK CONSTRAINT [FK_DressEarring_DressSupplier]
GO
