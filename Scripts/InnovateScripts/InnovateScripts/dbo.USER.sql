CREATE TABLE [dbo].[User] (
    [UserId]     INT              IdENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)    NOT NULL,
    [LastName]   NVARCHAR (50)    NOT NULL,
    [ScreenName] NVARCHAR (50)    NOT NULL,
    [Identifier]  UNIQUEIdentifier NOT NULL,
    [IsActive]   BIT              NOT NULL,
    [CreateDate] DATE             NOT NULL,
    [CreateBy]   NVARCHAR (50)    NOT NULL,
    [ChangeDate] DATE             NOT NULL,
    [ChangeBy]   NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

