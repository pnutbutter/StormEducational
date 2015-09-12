CREATE TABLE [dbo].[AppPackage] (
    [AppPackageId]				 INT              IDENTITY (1, 1) NOT NULL,
	[AppId]				 INT			  NOT NULL,
	[SubscriptionId]	 INT			  NOT NULL,
	[PackageName]        NVARCHAR (50)    NOT NULL,
    [PackageDescription] NVARCHAR (MAX)   NOT NULL,
    [PackagePrice]       DECIMAL (18, 2)  NOT NULL,
    [PackageTypeId]      INT              NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([AppPackageId] ASC),
	CONSTRAINT [FK_dbo.AppPackage_dbo.AppAppId] FOREIGN KEY ([AppId]) REFERENCES [dbo].[App] ([AppId]),
    CONSTRAINT [FK_dbo.AppPackage_dbo.SubscriptionSubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscription] ([SubscriptionId])
);
