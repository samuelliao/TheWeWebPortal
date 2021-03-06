USE [TheWe]
GO
/****** Object:  Table [dbo].[ApprovalRating]    Script Date: 2016/8/19 下午 05:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalRating](
	[Id] [uniqueidentifier] NOT NULL,
	[ObjectId] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
	[UpdateAccId] [uniqueidentifier] NULL,
	[UpdateTime] [datetime] NULL,
	[CreatedateAccId] [uniqueidentifier] NULL,
	[CreatedateTime] [datetime] NULL,
 CONSTRAINT [PK_ApprovalRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF_ApprovalRating_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF_ApprovalRating_Score]  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF__ApprovalR__IsDel__246854D6]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ApprovalRating] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[ApprovalRating] ADD  CONSTRAINT [DF_ApprovalRating_CreatedateTime]  DEFAULT (getdate()) FOR [CreatedateTime]
GO
