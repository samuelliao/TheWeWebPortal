USE [TheWe]
GO
/****** Object:  Table [dbo].[DressShawl]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressShawl](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Number] [int] NULL,
	[Img] [varchar](max) NULL,
	[StatusCode] [uniqueidentifier] NULL,
	[RentRecord] [bit] NULL,
	[Cost] [money] NULL,
	[SupplierId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [uniqueidentifier] NULL,
	[Color] [nvarchar](max) NULL,
	[Material] [nvarchar](max) NULL,
	[RentPrice] [money] NULL,
	[SellsPrice] [money] NULL,
	[OptionalPrice] [money] NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_DressShawl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressShawl] ADD  CONSTRAINT [DF_DressShawl_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressShawl] ADD  CONSTRAINT [DF__DressShaw__IsDel__41049384]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressShawl] ADD  CONSTRAINT [DF__DressShaw__Updat__3ED2324F]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressShawl] ADD  CONSTRAINT [DF__DressShaw__Creat__15A5FF8A]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
ALTER TABLE [dbo].[DressShawl]  WITH CHECK ADD  CONSTRAINT [FK_DressShawl_DressCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[DressCategory] ([Id])
GO
ALTER TABLE [dbo].[DressShawl] CHECK CONSTRAINT [FK_DressShawl_DressCategory]
GO
ALTER TABLE [dbo].[DressShawl]  WITH CHECK ADD  CONSTRAINT [FK_DressShawl_DressStatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[DressStatusCode] ([Id])
GO
ALTER TABLE [dbo].[DressShawl] CHECK CONSTRAINT [FK_DressShawl_DressStatusCode]
GO
ALTER TABLE [dbo].[DressShawl]  WITH CHECK ADD  CONSTRAINT [FK_DressShawl_DressSupplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[DressSupplier] ([Id])
GO
ALTER TABLE [dbo].[DressShawl] CHECK CONSTRAINT [FK_DressShawl_DressSupplier]
GO
