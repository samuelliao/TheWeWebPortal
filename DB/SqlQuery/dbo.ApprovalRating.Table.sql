USE [TheWe]
GO
/****** Object:  Table [dbo].[ApprovalRating]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalRating](
	[Id] [uniqueidentifier] NOT NULL,
	[ObjectId] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_ApprovalRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF_ApprovalRating_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF_ApprovalRating_Score]  DEFAULT ((0)) FOR [Score]
GO
