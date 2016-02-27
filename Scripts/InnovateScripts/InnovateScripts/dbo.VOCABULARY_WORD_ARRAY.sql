CREATE TABLE [dbo].[VocabularyWordArray] (
    [VocabularyWordArrayId]		 INT              IDENTITY (1, 1) NOT NULL,
	[VocabularyId]		 INT			  NOT NULL,
	[WordArrayId]	 INT			  NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([VocabularyWordArrayId] ASC),
	CONSTRAINT [FK_dbo.VocabularyWordArray_dbo.VocabularyVocabularyId] FOREIGN KEY ([VocabularyId]) REFERENCES [dbo].[Vocabulary] ([VocabularyId]),
	CONSTRAINT [FK_dbo.VocabularyWordArray_dbo.WordArrayWordArrayId] FOREIGN KEY ([WordArrayId]) REFERENCES [dbo].[WordArray] ([WordArrayId])
);