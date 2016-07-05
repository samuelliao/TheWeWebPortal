USE [TheWe]
GO
/****** Object:  Table [dbo].[Consultation]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consultation](
	[Id] [uniqueidentifier] NOT NULL,
	[Sn] [varchar](10) NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[SeekerGender] [bit] NOT NULL,
	[BridalName] [varchar](10) NULL,
	[BridalEnName] [varchar](50) NULL,
	[BridalPhone] [varchar](50) NULL,
	[BridalBday] [date] NULL,
	[BridalEmail] [varchar](50) NULL,
	[BridalWork] [varchar](50) NULL,
	[BridalMsgerType] [uniqueidentifier] NULL,
	[BridalMsgerId] [varchar](50) NULL,
	[GroomName] [varchar](10) NULL,
	[GroomEnName] [varchar](50) NULL,
	[GroomPhone] [varchar](50) NULL,
	[GroomWork] [varchar](50) NULL,
	[GroomBday] [date] NULL,
	[GroomEmail] [varchar](50) NULL,
	[GroomMsgerType] [uniqueidentifier] NULL,
	[GroomMsgerId] [nchar](10) NULL,
	[OverseaWedding] [bit] NULL,
	[OverseaFilming] [bit] NULL,
	[LocalFilming] [bit] NULL,
	[WeddingConsult] [bit] NULL,
	[FilmingDate] [date] NULL,
	[WeddingDate] [date] NULL,
	[ReceptionDate] [date] NULL,
	[StatusId] [uniqueidentifier] NULL,
	[LastReceivedDate] [datetime] NULL,
	[Remark] [varchar](50) NULL,
	[ConsultDate] [datetime] NULL,
	[IsReply] [bit] NOT NULL,
	[InfoSource] [bit] NOT NULL,
	[CloseDate] [datetime] NULL,
	[ContractDate] [datetime] NULL,
	[ReservationDate] [datetime] NULL,
	[ContactMethod] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Consultation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Consultation] ADD  CONSTRAINT [DF_Consultation_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_ConsultStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ConsultStatus] ([Id])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_ConsultStatus]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_Store]
GO
