USE [TheWe]
GO
/****** Object:  Table [dbo].[ServiceItemCategory]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceItemCategory](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ServiceItemCategory_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [uniqueidentifier] NULL,
	[EngName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__ServiceIt__IsDel__61716316]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__ServiceIt__Updat__6033261A]  DEFAULT (getdate()),
	[TypeLv] [int] NULL,
	[Sn] [nvarchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__ServiceIt__Creat__39E36000]  DEFAULT (getdate()),
	[Code] [nvarchar](10) NULL,
 CONSTRAINT [PK_ServiceItemCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0, belongs to store ''s service item
1, is church special service only.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServiceItemCategory', @level2type=N'COLUMN',@level2name=N'Type'
GO
