CREATE TABLE [dbo].[UserRole] (
    [UserRoleId] INT           IdENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [RoleId]      INT           NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [CreateDate]  DATE          NOT NULL,
    [CreateBy]    NVARCHAR (50) NOT NULL,
    [ChangeDate]  DATE          NOT NULL,
    [ChangeBy]    NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_dbo.UserRole_dbo.UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_dbo.UserRole_dbo.UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

