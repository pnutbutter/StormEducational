CREATE TABLE [dbo].[App] (
    [AppId]				 INT              IDENTITY (1, 1) NOT NULL,
	[AppGUID]            UNIQUEIdentifier NOT NULL,
	[AppKey]             UNIQUEIdentifier NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([AppId] ASC)
);
