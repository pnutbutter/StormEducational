CREATE TABLE [dbo].[Group] (
    [GroupId]      INT           IdENTITY (1, 1) NOT NULL,
    [GroupTypeId] INT           NOT NULL,
    [GroupName]    NVARCHAR (50) NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [CreateDate]   DATE          NOT NULL,
    [CreateBy]     NVARCHAR (50) NOT NULL,
    [ChangeDate]   DATE          NOT NULL,
    [ChangeBy]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([GroupId] ASC),
    CONSTRAINT [FK_dbo.Groupdbo.GroupType_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [dbo].[GroupType] ([GroupTypeId])
);

