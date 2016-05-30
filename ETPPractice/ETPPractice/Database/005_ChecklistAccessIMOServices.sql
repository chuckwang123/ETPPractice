 IF NOT EXISTS (
 	SELECT * FROM INFORMATION_SCHEMA.TABLES
 	WHERE TABLE_NAME = 'ChecklistAccessIMOServices')
 BEGIN
 	CREATE TABLE dbo.ChecklistAccessIMOServices(
 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 		checkList_id int NOT NULL FOREIGN KEY REFERENCES Checklist(CheckListId),
 		service_id int NOT NULL FOREIGN KEY REFERENCES ChecklistIMOService(id),
 		validate_by varchar(50) NOT NULL Default(NULL),
 		access_date datetime NOT NULL DEFAULT (getdate()),
 		notes nvarchar(4000) NOT NULL
 	)
 END
 GO