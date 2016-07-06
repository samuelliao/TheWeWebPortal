USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Partner]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwEN_Partner]
AS
SELECT [Id]
,[Name]
      ,[EngName]
      ,[Bday]= CAST(DECRYPTBYKEY(EnBday) AS date)
      ,[MessengerType]
      ,[MessengerId]= CAST(DECRYPTBYKEY(EnMessengerId) AS varchar)
      ,[Phone]= CAST(DECRYPTBYKEY(EnPhone) AS varchar)
      ,[OrderId]
      ,[Email]= CAST(DECRYPTBYKEY(EnEmail) AS varchar)
      ,[Works]
      ,[NickName]
      ,[PhotoImg]= CAST(DECRYPTBYKEY(EnPhotoImg) AS varchar)
FROM [Partner];


GO
