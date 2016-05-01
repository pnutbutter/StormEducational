CREATE TABLE [dbo].[Group] (
    [GroupId]     INT           IDENTITY (1, 1) NOT NULL,
    [GroupTypeId] INT           NOT NULL,
    [GroupName]   NVARCHAR (50) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [CreateDate]  DATE          NOT NULL,
    [CreateBy]    NVARCHAR (50) NOT NULL,
    [ChangeDate]  DATE          NOT NULL,
    [ChangeBy]    NVARCHAR (50) NOT NULL,
    [OwnerUserId] INT NULL, 
    PRIMARY KEY CLUSTERED ([GroupId] ASC),
    CONSTRAINT [FK_dbo.Groupdbo.GroupType_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [dbo].[GroupType] ([GroupTypeId]),
	CONSTRAINT [FK_dbo.Groupdbo.User_OwnerUserId] FOREIGN KEY ([OwnerUserId]) REFERENCES [dbo].[User] ([UserId])
);

