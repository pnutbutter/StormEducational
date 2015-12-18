CREATE TABLE [dbo].[UserGroup] (
    [UserGroupId] INT           IdENTITY (1, 1) NOT NULL,
    [UserId]       INT           NOT NULL,
    [GroupId]	   INT		 NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [CreateDate]   DATE          NOT NULL,
    [CreateBy]     NVARCHAR (50) NOT NULL,
    [ChangeDate]   DATE          NOT NULL,
    [ChangeBy]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserGroupId] ASC),
    CONSTRAINT [FK_dbo.UserGroupdbo.UserUserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_dbo.UserGroupdbo.UserGroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([GroupId])
);

