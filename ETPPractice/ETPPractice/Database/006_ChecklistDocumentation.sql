 IF NOT EXISTS (
 	SELECT * FROM INFORMATION_SCHEMA.TABLES
 	WHERE TABLE_NAME = 'ChecklistDocumentation')
 BEGIN
 	CREATE TABLE dbo.ChecklistDocumentation(
 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 		documentation_name nvarchar(50) NOT NULL,
 		media_format nvarchar(50) NOT NULL,
 		item_order int NOT NULL
 	)
 END
 GO

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'This is 2.0' AND media_format ='Webinar' AND item_order = 1)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(1,'This is 2.0','Webinar')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'IMO 2.0 Installation Guide' AND media_format ='PDF' AND item_order = 2)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(2,'IMO 2.0 Installation Guide','PDF')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'IMO 2.0 Server Requirements Guide' AND media_format ='PDF' AND item_order = 3)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(3,'IMO 2.0 Server Requirements Guide','PDF')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'ShareFile documentation / Demonstration' AND media_format ='PDF|Video' AND item_order = 4)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(4,'ShareFile documentation / Demonstration','PDF|Video')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'MapIT documentation / Demonstration' AND media_format ='PDF|Video' AND item_order = 5)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(5,'MapIT documentation / Demonstration','PDF|Video')

 IF NOT EXISTS (SELECT * FROM dbo.ChecklistDocumentation WHERE documentation_name = 'LTTM documentation / Demonstration' AND media_format ='PDF|Video' AND item_order = 6)
 INSERT INTO [dbo].[ChecklistDocumentation]([item_order],[documentation_name],[media_format])
 VALUES(6,'LTTM documentation / Demonstration','PDF|Video')