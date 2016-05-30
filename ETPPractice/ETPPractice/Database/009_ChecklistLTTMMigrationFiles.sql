 IF NOT EXISTS (
 	SELECT * FROM INFORMATION_SCHEMA.TABLES
 	WHERE TABLE_NAME = 'ChecklistLTTMMigrationFiles')
 BEGIN
 	CREATE TABLE dbo.ChecklistLTTMMigrationFiles(
 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 		checkList_id int NOT NULL FOREIGN KEY REFERENCES Checklist(CheckListId),
 		dictionary_Id int NOT NULL FOREIGN KEY REFERENCES ChecklistLTTMDictionary(id),
 		isSendFile bit NOT NULL Default(0),
 		Reason nvarchar(4000) NOT NULL,
 		reviewed_migration bit NOT NULL Default(0),
 		export_info datetime NOT NULL DEFAULT (getdate())
 	)
 END
 GO