CREATE TABLE [dbo].[VocabularyAssignment] (
    [VocabularyAssignmentId]		 INT              IDENTITY (1, 1) NOT NULL,
	[AssignmentId]	 INT			  NOT NULL,
	[VocabularyId]	 INT			  NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([VocabularyAssignmentId] ASC),
	CONSTRAINT [FK_dbo.VocabularyAssignment_dbo.AssignmentAssignmentId] FOREIGN KEY ([AssignmentId]) REFERENCES [dbo].[Assignment] ([AssignmentId]),
	CONSTRAINT [FK_dbo.VocabularyAssignment_dbo.VocabularyVocabularyId] FOREIGN KEY ([AssignmentId]) REFERENCES [dbo].[Assignment] ([AssignmentId])
);
