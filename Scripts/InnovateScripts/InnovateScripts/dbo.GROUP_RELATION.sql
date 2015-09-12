CREATE TABLE [dbo].[GroupRelation] (
    [GroupRelationId] INT           IdENTITY (1, 1) NOT NULL,
    [ChildGroupId]    INT           NOT NULL,
    [ParentGroupId]   INT           NOT NULL,
    [IsActive]         BIT           NOT NULL,
    [CreateDate]       DATE          NOT NULL,
    [CreateBy]         NVARCHAR (50) NOT NULL,
    [ChangeDate]       DATE          NOT NULL,
    [ChangeBy]         NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([GroupRelationId] ASC),
    CONSTRAINT [FK_dbo.GroupRelation_dbo.GroupChildGroupId] FOREIGN KEY ([ChildGroupId]) REFERENCES [dbo].[Group] ([GroupId]),
    CONSTRAINT [FK_dbo.GroupRelation_dbo.GroupParentGroupId] FOREIGN KEY ([ParentGroupId]) REFERENCES [dbo].[Group] ([GroupId])
);

