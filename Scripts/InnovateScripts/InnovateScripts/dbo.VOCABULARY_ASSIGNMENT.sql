Drop table [dbo].[VocabularyAssignment];

CREATE TABLE [dbo].[VocabularyAssignment] (
    [VocabularyAssignmentId] INT           IDENTITY (1, 1) NOT NULL,
    [UserAssignmentId]           INT           NOT NULL,
    [VocabularyId]           INT           NOT NULL,
    [IsActive]               BIT           NOT NULL,
    [CreateDate]             DATE          NOT NULL,
    [CreateBy]               NVARCHAR (50) NOT NULL,
    [ChangeDate]             DATE          NOT NULL,
    [ChangeBy]               NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([VocabularyAssignmentId] ASC),
    CONSTRAINT [FK_dbo.VocabularyAssignment_dbo.UserAssignmentUserAssignmentId] FOREIGN KEY ([UserAssignmentId]) REFERENCES [dbo].[UserAssignment] ([UserAssignmentId]),
    CONSTRAINT [FK_dbo.VocabularyAssignment_dbo.VocabularyVocabularyId] FOREIGN KEY ([VocabularyId]) REFERENCES [dbo].[Vocabulary] ([VocabularyId])
);

