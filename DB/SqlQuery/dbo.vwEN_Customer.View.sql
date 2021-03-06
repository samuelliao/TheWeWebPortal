USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Customer]    Script Date: 2016/8/19 下午 05:02:30 ******/
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
      ,[Bday]
      ,[Remark]
      ,[IsValid]
      ,[MessengerType]
      ,[MessengerId]= CAST(DECRYPTBYKEY(EnMessengerId) AS varchar)
      ,[StoreId]
      ,[Gender]
      ,[MsgTitle]
      ,[PhotoImg]= CAST(DECRYPTBYKEY(EnPhotoImg) AS varchar)
	  ,[IsDelete]
	  ,[UpdateAccId]
	  ,[UpdateTime]
	  ,[Works]
	  ,CreatedateAccId
	  ,CreatedateTime
FROM [Customer];







GO
