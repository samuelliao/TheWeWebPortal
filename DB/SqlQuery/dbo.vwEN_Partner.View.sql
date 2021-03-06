USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Partner]    Script Date: 2016/8/19 下午 05:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vwEN_Partner]
AS
SELECT [Id]
,[Name]
      ,[EngName]
      ,[Bday]
      ,[MessengerType]
      ,[MessengerId]= CAST(DECRYPTBYKEY(EnMessengerId) AS varchar)
      ,[Phone]= CAST(DECRYPTBYKEY(EnPhone) AS varchar)
      ,[OrderId]
      ,[Email]= CAST(DECRYPTBYKEY(EnEmail) AS varchar)
      ,[Works]
      ,[NickName]
      ,[PhotoImg]= CAST(DECRYPTBYKEY(EnPhotoImg) AS varchar)
	  ,[IsDelete]
	  ,[UpdateAccId]
	  ,[UpdateTime]
	  ,CreatedateAccId
	  ,CreatedateTime
FROM [Partner];





GO
