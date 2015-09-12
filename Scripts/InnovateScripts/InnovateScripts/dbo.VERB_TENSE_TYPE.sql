CREATE TABLE [dbo].[VerbTenseType] (
    [VerbTenseTypeId]     INT           IdENTITY (1, 1) NOT NULL,
    [VerbTenseTypeName]   NVARCHAR (50) NOT NULL,
    [IsActive]   BIT           NOT NULL,
    [CreateDate] DATE          NOT NULL,
    [CreateBy]   NVARCHAR (50) NOT NULL,
    [ChangeDate] DATE          NOT NULL,
    [ChangeBy]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([VerbTenseTypeId] ASC)
);

