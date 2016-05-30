-- IF NOT EXISTS (
-- 	SELECT * FROM INFORMATION_SCHEMA.TABLES
-- 	WHERE TABLE_NAME = 'ChecklistContactRole')
-- BEGIN
-- 	CREATE TABLE dbo.ChecklistContactRole(
-- 		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
-- 		role nvarchar(50) NOT NULL,
-- 		item_order int NOT NULL
-- 	)
-- END
-- GO


-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'IMO 2.0 ETP Primary Contact' AND item_order = 1)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(1,'IMO 2.0 ETP Primary Contact')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = '2.0 ETP Clinical Lead' AND item_order = 2)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(2,'2.0 ETP Clinical Lead')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'IT Administrator' AND item_order = 3)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(3,'IT Administrator')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'IT Technician (2.0 ETP maintenance)' AND item_order = 4)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(4,'IT Technician (2.0 ETP maintenance)')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'MEDITECH EHR Administrator' AND item_order = 5)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(5,'MEDITECH EHR Administrator')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'ShareFile Primary Contact' AND item_order = 6)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(6,'ShareFile Primary Contact')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'CQM Primary Contact' AND item_order = 7)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(7,'CQM Primary Contact')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'MapIT Primary Contact' AND item_order = 8)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(8,'MapIT Primary Contact')

-- IF NOT EXISTS (SELECT * FROM dbo.ChecklistContactRole WHERE role = 'LTTM Primary Contact' AND item_order = 9)
-- INSERT INTO [dbo].[ChecklistContactRole]([item_order],[role])
-- VALUES(9,'LTTM Primary Contact')