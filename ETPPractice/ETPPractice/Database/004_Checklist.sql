IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Checklist'
)
BEGIN
	CREATE TABLE dbo.Checklist (
		ChecklistId int IDENTITY(1,1) NOT NULL,
		CRMOpportunityId uniqueidentifier,
		 OrganizationName nvarchar(4000) NOT NULL,
		 WebinarDateTime datetime2(0) NOT NULL,
		 AdditionalContactInfo nvarchar(500) NOT NULL DEFAULT (NULL),
		 LTTMMarkAllYes bit NOT NULL DEFAULT(0)
		CONSTRAINT Checklist_ChecklistId_PK PRIMARY KEY (ChecklistId)
	)
END
