USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Employee]    Script Date: 2016/7/6 上午 10:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwEN_Employee]
AS
SELECT [Id]
      ,[CountryId]
      ,[Sn]
      ,[Name]
      ,[Account]
      ,[Password]
      ,[Addr] = CAST(DECRYPTBYKEY(EnAddr) AS varchar)
      ,[Phone] = CAST(DECRYPTBYKEY(EnAddr) AS varchar)
      ,[Bday] = CAST(DECRYPTBYKEY(EnBday) AS DATE) --將資料解密轉成DATE
      ,[OnBoard]
      ,[QuitDay]
      ,[Salary] = CAST(DECRYPTBYKEY(EnSalary) AS money) --將資料解密轉成DATE
      ,[CurrencyId]
      ,[Remark]
      ,[StoreId]
      ,[IsValid]
FROM [Employee];

GO
