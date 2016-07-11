USE [TheWe]
GO
/****** Object:  Table [dbo].[DressNecklace]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressNecklace](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [varchar](max) NULL,
	[Color] [bit] NULL,
	[Material] [bit] NULL,
	[Type] [uniqueidentifier] NULL,
	[Earring] [bit] NULL,
	[Img] [varchar](max) NULL,
	[Number] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[StatusCode] [uniqueidentifier] NULL,
 CONSTRAINT [PK_DressNecklace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressCategory2] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressCategory2]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressCategory3] FOREIGN KEY([Type])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressCategory3]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressStatusCode]
GO
ALTER TABLE [dbo].[DressNecklace]  WITH CHECK ADD  CONSTRAINT [FK_DressNecklace_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressNecklace] CHECK CONSTRAINT [FK_DressNecklace_DressSupplier]
GO
