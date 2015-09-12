CREATE TABLE [dbo].[Assignment] (
    [AssignmentId]		 INT              IDENTITY (1, 1) NOT NULL,
	[AssignmentTypeId]	 INT			  NOT NULL,
	[AssignmentParentId] INT,
	[DueDate]            date,
	[AssignmentTitle]					  NVARCHAR(250) NOT NULL,
	[AssignmentDescription]				  NVARCHAR(Max) NOT NULL,
	[AssignmentSpanishTitle]			  NVARCHAR(250),
	[AssignmentSpanishDescription]		  NVARCHAR(Max),
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([AssignmentId] ASC),
	CONSTRAINT [FK_dbo.Assignment_dbo.AssignmentTypeAssignmentTypeId] FOREIGN KEY ([AssignmentTypeId]) REFERENCES [dbo].[AssignmentType] ([AssignmentTypeId]),
	CONSTRAINT [FK_dbo.Assignment_dbo.AssignmentAssignmentParentId] FOREIGN KEY ([AssignmentParentId]) REFERENCES [dbo].[Assignment] ([AssignmentId])
);
