USE [TheWe]
GO
/****** Object:  Table [dbo].[OrderResponsible]    Script Date: 2016/7/5 下午 12:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderResponsible](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OrderResponsible] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrderResponsible] ADD  CONSTRAINT [DF_OrderResponsible_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[OrderResponsible]  WITH CHECK ADD  CONSTRAINT [FK_OrderResponsible_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[OrderResponsible] CHECK CONSTRAINT [FK_OrderResponsible_Employee]
GO
ALTER TABLE [dbo].[OrderResponsible]  WITH CHECK ADD  CONSTRAINT [FK_OrderResponsible_OrderInfo] FOREIGN KEY([OrderId])
REFERENCES [dbo].[OrderInfo] ([Id])
GO
ALTER TABLE [dbo].[OrderResponsible] CHECK CONSTRAINT [FK_OrderResponsible_OrderInfo]
GO
