USE [TheWe]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Currency_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Rate] [money] NULL,
	[UpdateAccId] [uniqueidentifier] NOT NULL,
	[UpdateTime] [datetime] NOT NULL DEFAULT (getdate()),
	[IsDelete] [bit] NULL CONSTRAINT [DF__Currency__IsDele__2EE5E349]  DEFAULT ((0)),
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL DEFAULT (getdate()),
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_Currency] FOREIGN KEY([Id])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_Currency]
GO
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_Employee] FOREIGN KEY([UpdateAccId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_Employee]
GO
