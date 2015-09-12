CREATE TABLE [dbo].[UserRelation] (
    [UserRelationId] INT           IdENTITY (1, 1) NOT NULL,
    [ChildUserId]    INT           NOT NULL,
    [ParentUserId]   INT           NOT NULL,
    [IsActive]        BIT           NOT NULL,
    [CreateDate]      DATE          NOT NULL,
    [CreateBy]        NVARCHAR (50) NOT NULL,
    [ChangeDate]      DATE          NOT NULL,
    [ChangeBy]        NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserRelationId] ASC),
    CONSTRAINT [FK_dbo.UserRelation_dbo.UserChildUserId] FOREIGN KEY ([ChildUserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_dbo.UserRelation_dbo.UserParentUserId] FOREIGN KEY ([ParentUserId]) REFERENCES [dbo].[User] ([UserId])
);

