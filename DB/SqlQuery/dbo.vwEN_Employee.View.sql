USE [TheWe]
GO
/****** Object:  View [dbo].[vwEN_Employee]    Script Date: 2016/7/10 下午 06:09:26 ******/
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
	  ,[Addr2] = CAST(DECRYPTBYKEY(EnAddr2) AS varchar)
      ,[PassportId] = CAST(DECRYPTBYKEY(EnPassportId) AS varchar)
      ,[PassportName]
      ,[IdCardImg] = CAST(DECRYPTBYKEY(EnIdCardImg) AS varchar)
      ,[BankBookImg]
      ,[BankAccount]
      ,[EmContName] 
      ,[EmContPhone] = CAST(DECRYPTBYKEY(EnEmContPhone) AS varchar)
      ,[EmContMail] = CAST(DECRYPTBYKEY(EnEmContMail) AS varchar)
      ,[PhotoImg]
      ,[InsuranceId]
      ,[EnAddr2]
      ,[EnEmContPhone]
      ,[EnEmContMail]
      ,[EnPassportId]
      ,[PersonalId] = CAST(DECRYPTBYKEY(EnPersonalId) AS varchar)
FROM [Employee];


GO
