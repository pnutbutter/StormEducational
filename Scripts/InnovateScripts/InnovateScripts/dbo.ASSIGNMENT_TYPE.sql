CREATE TABLE [dbo].[AssignmentType] (
    [AssignmentTypeId]		 INT              IDENTITY (1, 1) NOT NULL,
	[AssignmentTypeTitle]					  NVARCHAR(250) NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([AssignmentTypeId] ASC)
);