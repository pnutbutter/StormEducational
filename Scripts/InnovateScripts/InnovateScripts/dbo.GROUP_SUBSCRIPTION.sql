CREATE TABLE [dbo].[GroupSubscription] (
    [GroupSubscriptionId] INT            IdENTITY (1, 1) NOT NULL,
    [SubscriptionId]       INT            NOT NULL,
    [GroupId]              INT            NOT NULL,
    [LastPayment]          DECIMAL (8, 2) NULL,
    [LastPaymentDate]     DATE           NULL,
    [IsActive]             BIT            NOT NULL,
    [CreateDate]           DATE           NOT NULL,
    [CreateBy]             NVARCHAR (50)  NOT NULL,
    [ChangeDate]           DATE           NOT NULL,
    [ChangeBy]             NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([GroupSubscriptionId] ASC),
    CONSTRAINT [FK_dbo.GroupSubscription_dbo.GroupGroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([GroupId]),
    CONSTRAINT [FK_dbo.GroupSubscription_dbo.Subscription_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscription] ([SubscriptionId])
);

