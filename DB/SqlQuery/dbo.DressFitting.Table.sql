USE [TheWe]
GO
/****** Object:  Table [dbo].[DressFitting]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DressFitting](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[EngName] [nvarchar](50) NULL,
	[JpName] [nvarchar](50) NULL,
	[CnName] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[Img] [varchar](max) NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_Fitting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DressFitting] ADD  CONSTRAINT [DF_Fitting_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DressFitting] ADD  CONSTRAINT [DF__DressFitt__IsDel__396371BC]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[DressFitting] ADD  CONSTRAINT [DF__DressFitt__Updat__37311087]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[DressFitting] ADD  CONSTRAINT [DF__DressFitt__Creat__0E04DDC2]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
