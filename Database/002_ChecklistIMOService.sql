-- IF NOT EXISTS (
-- 	SELECT * FROM INFORMATION_SCHEMA.TABLES
-- 	WHERE TABLE_NAME = 'ChecklistIMOService')
-- BEGIN
-- 	CREATE TABLE dbo.ChecklistIMOService(
-- 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
-- 		service_name varchar(50) NOT NULL,
-- 		item_order int NOT NULL
-- 	)
-- END
-- GO

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'MapIT' AND item_order = 1)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(1,'MapIT')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'CQM Dashboard' AND item_order = 2)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(2,'CQM Dashboard')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'ShareFile' AND item_order = 3)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(3,'ShareFile')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'IMO Affiliates Webpage' AND item_order = 4)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(4,'IMO Affiliates Webpage')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'Intelligent Service Desk' AND item_order = 5)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(5,'Intelligent Service Desk')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'IMO Anywhere' AND item_order = 6)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(6,'IMO Anywhere')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistIMOService WHERE service_name = 'IMO University' AND item_order = 7)
-- INSERT INTO [dbo].[ChecklistIMOService]([item_order],[service_name])
-- VALUES(7,'IMO University')