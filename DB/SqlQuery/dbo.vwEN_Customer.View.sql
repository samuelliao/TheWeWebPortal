USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Customer]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwEN_Customer]
AS
SELECT [Id]
      ,[CountryId]
      ,[Sn]
      ,[Name]
      ,[EngName]
      ,[Account]
      ,[Nickname]
      ,[Password]
      ,[Addr]= CAST(DECRYPTBYKEY(EnAddr) AS varchar)
      ,[Phone]= CAST(DECRYPTBYKEY(EnPhone) AS varchar)
      ,[CellPhone]= CAST(DECRYPTBYKEY(EnAddr) AS varchar)
      ,[Email]= CAST(DECRYPTBYKEY(EnEmail) AS varchar)
      ,[Bday]= CAST(DECRYPTBYKEY(EnBday) AS date)
      ,[Remark]
      ,[IsValid]
      ,[MessengerType]
      ,[MessengerId]= CAST(DECRYPTBYKEY(EnMessengerId) AS varchar)
      ,[StoreId]
      ,[Gender]
      ,[InfoSource]
      ,[MsgTitle]
      ,[PhotoImg]= CAST(DECRYPTBYKEY(EnPhotoImg) AS varchar)
FROM [Customer];


GO
