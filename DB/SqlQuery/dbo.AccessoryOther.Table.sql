USE [TheWe]
GO
/****** Object:  Table [dbo].[AccessoryOther]    Script Date: 2016/7/11 下午 02:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccessoryOther](
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
	[Type] [uniqueidentifier] NULL,
	[Length] [int] NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
 CONSTRAINT [PK_AccessoryOther] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AccessoryOther] ADD  CONSTRAINT [DF_AccessoryOther_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[AccessoryOther]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryOther_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[AccessoryOther] CHECK CONSTRAINT [FK_AccessoryOther_DressCategory]
GO
ALTER TABLE [dbo].[AccessoryOther]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryOther_DressCategory1] FOREIGN KEY([Type])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[AccessoryOther] CHECK CONSTRAINT [FK_AccessoryOther_DressCategory1]
GO
ALTER TABLE [dbo].[AccessoryOther]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryOther_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[AccessoryOther] CHECK CONSTRAINT [FK_AccessoryOther_DressStatusCode]
GO
