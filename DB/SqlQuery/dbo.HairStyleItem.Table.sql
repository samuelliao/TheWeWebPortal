USE [TheWe]
GO
/****** Object:  Table [dbo].[HairStyleItem]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HairStyleItem](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_HairStyleItem_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[Type] [uniqueidentifier] NULL,
	[Img] [varchar](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__HairStyle__IsDel__4C764630]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__HairStyle__Updat__4A43E4FB]  DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[StoreId] [uniqueidentifier] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__HairStyle__Creat__220BD66F]  DEFAULT (getdate()),
 CONSTRAINT [PK_HairStyleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[HairStyleItem]  WITH CHECK ADD  CONSTRAINT [FK_HairStyleItem_HairStyleCategory] FOREIGN KEY([Type])
REFERENCES [dbo].[HairStyleCategory] ([Id])
GO
ALTER TABLE [dbo].[HairStyleItem] CHECK CONSTRAINT [FK_HairStyleItem_HairStyleCategory]
GO
