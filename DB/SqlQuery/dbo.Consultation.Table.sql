USE [TheWe]
GO
/****** Object:  Table [dbo].[Consultation]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consultation](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Consultation_Id]  DEFAULT (newid()),
	[Sn] [nvarchar](max) NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[SeekerGender] [bit] NOT NULL,
	[BridalName] [nvarchar](50) NULL,
	[BridalEngName] [varchar](50) NULL,
	[BridalPhone] [varchar](50) NULL,
	[EnBridalPhone] [varbinary](max) NULL,
	[BridalBday] [date] NULL,
	[EnBridalBday] [varbinary](max) NULL,
	[BridalEmail] [varchar](50) NULL,
	[EnBridalEmail] [varbinary](max) NULL,
	[BridalWork] [nvarchar](50) NULL,
	[BridalMsgerType] [uniqueidentifier] NULL,
	[BridalMsgerId] [varchar](50) NULL,
	[EnBridalMsgerId] [varbinary](max) NULL,
	[GroomName] [nvarchar](50) NULL,
	[GroomEngName] [varchar](50) NULL,
	[GroomPhone] [varchar](50) NULL,
	[EnGroomPhone] [varbinary](max) NULL,
	[GroomWork] [nvarchar](50) NULL,
	[GroomBday] [date] NULL,
	[EnGroomBday] [varbinary](max) NULL,
	[GroomEmail] [varchar](50) NULL,
	[EnGroomEmail] [varbinary](max) NULL,
	[GroomMsgerType] [uniqueidentifier] NULL,
	[GroomMsgerId] [varchar](50) NULL,
	[EnGroomMsgerId] [varbinary](max) NULL,
	[OverseaWedding] [bit] NULL,
	[OverseaFilming] [bit] NULL,
	[LocalFilming] [bit] NULL,
	[WeddingConsult] [bit] NULL,
	[FilmingDate] [date] NULL,
	[WeddingDate] [date] NULL,
	[ReceptionDate] [date] NULL,
	[StatusId] [uniqueidentifier] NULL,
	[LastReceivedDate] [datetime] NULL,
	[Remark] [nvarchar](max) NULL,
	[ConsultDate] [datetime] NULL,
	[IsReply] [bit] NOT NULL CONSTRAINT [DF_Consultation_IsReply]  DEFAULT ((0)),
	[InfoSource] [bit] NULL,
	[CloseDate] [datetime] NULL,
	[ContractDate] [datetime] NULL,
	[BookingDate] [datetime] NULL,
	[ContactMethod] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL CONSTRAINT [DF__Consultat__IsDel__292D09F3]  DEFAULT ((0)),
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL CONSTRAINT [DF__Consultat__Updat__29D71569]  DEFAULT (getdate()),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL CONSTRAINT [DF_Consultation_CreatedateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Consultation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_Store]
GO
