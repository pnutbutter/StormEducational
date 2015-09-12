CREATE TABLE [dbo].[UserSubscription] (
    [UserSubscriptionId] INT            IdENTITY (1, 1) NOT NULL,
    [SubscriptionId]      INT            NOT NULL,
    [UserId]              INT            NOT NULL,
    [LastPayment]         DECIMAL (8, 2) NULL,
    [LastPaymentDate]    DATE           NULL,
    [IsActive]            BIT            NOT NULL,
    [CreateDate]          DATE           NOT NULL,
    [CreateBy]            NVARCHAR (50)  NOT NULL,
    [ChangeDate]          DATE           NOT NULL,
    [ChangeBy]            NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserSubscriptionId] ASC),
    CONSTRAINT [FK_dbo.UserSubscription_dbo.UserSubscription_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_dbo.UserSubscription_dbo.UserSubscription_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscription] ([SubscriptionId])
);

