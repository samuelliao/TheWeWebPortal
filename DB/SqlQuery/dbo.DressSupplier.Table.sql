USE [TheWe]
GO
/****** Object:  Table [dbo].[DressSupplier]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressSupplier](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](50) NULL,
	[Descirption] [nvarchar](max) NULL,
	[Country] [uniqueidentifier] NULL,
	[City] [uniqueidentifier] NULL,
	[IsValid] [bit] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF_Supplier_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF_DressSupplier_IsValid]  DEFAULT ((1)) FOR [IsValid]
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF__DressSupp__IsDel__43E1002F]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF__DressSupp__Updat__41AE9EFA]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressSupplier] ADD  CONSTRAINT [DF__DressSupp__Creat__18826C35]  DEFAULT (getdate()) FOR [CreatedateTime]
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
