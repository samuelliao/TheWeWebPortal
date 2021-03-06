USE [TheWe]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Store_Id]  DEFAULT (newid()),
	[Sn] [varchar](max) NULL,
	[CountryId] [uniqueidentifier] NULL,
	[AreaId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[Addr] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CnName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Store__IsDelete__6265874F]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Store__UpdateTim__621B6E8C]  DEFAULT (getdate()),
	[HoldingCompany] [bit] NULL CONSTRAINT [DF_Store_HoldingCompany]  DEFAULT ((0)),
	[GradeLv] [int] NULL,
	[Code] [varchar](3) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF__Store__Createdat__3CBFCCAB]  DEFAULT (getdate()),
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Area]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Country]
GO
