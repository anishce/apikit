
DELETE FROM [dbo].[Category]
DBCC CHECKIDENT ('TaskManagementDB.dbo.Category', RESEED, 0)