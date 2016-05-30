 IF NOT EXISTS (
 	SELECT * FROM INFORMATION_SCHEMA.TABLES
 	WHERE TABLE_NAME = 'ChecklistContactInformation')
 BEGIN
 	CREATE TABLE dbo.ChecklistContactInformation(
 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 		checkList_id int NOT NULL FOREIGN KEY REFERENCES Checklist(CheckListId),
 		role_ID int NOt NULL FOREIGN KEY REFERENCES ChecklistContactRole(id),
 		name nvarchar(50) NOT NULL,
 		email nvarchar(50) NOT NULL,
 		org_position nvarchar(50) NOT NULL
 	)
 END
 GO