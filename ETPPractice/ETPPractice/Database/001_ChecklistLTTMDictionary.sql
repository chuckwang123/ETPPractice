 IF NOT EXISTS (
 	SELECT * FROM INFORMATION_SCHEMA.TABLES
 	WHERE TABLE_NAME = 'ChecklistLTTMDictionary')
 BEGIN
 	CREATE TABLE dbo.ChecklistLTTMDictionary(
 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 		dictionary nvarchar(50) NOT NULL,
 		item_order int NOT NULL
 	)
 END
 GO

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'MIS Problem' AND item_order = 1)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(1,'MIS Problem')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'OE Procedure' AND item_order = 2)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(2,'OE Procedure')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'EDM Chief Complaint' AND item_order = 3)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(3,'EDM Chief Complaint')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'NUR Interventions' AND item_order = 4)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(4,'NUR Interventions')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'SCH Anesthesia' AND item_order = 5)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(5,'SCH Anesthesia')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'RAD Procedure' AND item_order = 6)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(6,'RAD Procedure')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistLTTMDictionary WHERE dictionary = 'MIS Allergens' AND item_order = 7)
 INSERT INTO [dbo].[ChecklistLTTMDictionary]([item_order],[dictionary])
 VALUES(7,'MIS Allergens')