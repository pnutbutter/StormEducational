CREATE TABLE [dbo].[UserAssignment] (
    [UserAssignmentId]		 INT              IDENTITY (1, 1) NOT NULL,
	[AssignmentId]	 INT			  NOT NULL,
	[AssignedUserId]	 INT			  NOT NULL,
	[AssigningUserId]	 INT			  NOT NULL,
	[DueDate]            date,
	[Grade]				 int			  NOT NULL,
	[GradeDescription]	 NVARCHAR(MAX)	  NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [CreateDate]         DATE             NOT NULL,
    [CreateBy]           NVARCHAR (50)    NOT NULL,
    [ChangeDate]         DATE             NOT NULL,
    [ChangeBy]           NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([UserAssignmentId] ASC),
	CONSTRAINT [FK_dbo.UserAssignment_dbo.AssignmentAssignmentId] FOREIGN KEY ([AssignmentId]) REFERENCES [dbo].[Assignment] ([AssignmentId]),
	CONSTRAINT [FK_dbo.UserAssignment_dbo.UserAssignedUserId] FOREIGN KEY ([AssignedUserId]) REFERENCES [dbo].[User] ([UserId]),
	CONSTRAINT [FK_dbo.UserAssignment_dbo.UserAssigningUserId] FOREIGN KEY ([AssigningUserId]) REFERENCES [dbo].[User] ([UserId])
);
