/****** Object:  Table [dbo].[AppVisible]    Script Date: 9/10/2015 8:51:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AppVisible](
	[AppVisibleId] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[VisibilityTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[CreateBy] [nvarchar](50) NOT NULL,
	[ChangeDate] [date] NOT NULL,
	[ChangeBy] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AppVisibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AppVisible]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AppVisible_dbo.AppAppId] FOREIGN KEY([AppId])
REFERENCES [dbo].[App] ([AppId])
GO

ALTER TABLE [dbo].[AppVisible] CHECK CONSTRAINT [FK_dbo.AppVisible_dbo.AppAppId]
GO

ALTER TABLE [dbo].[AppVisible]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AppVisible_dbo.GroupGroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO

ALTER TABLE [dbo].[AppVisible] CHECK CONSTRAINT [FK_dbo.AppVisible_dbo.GroupGroupId]
GO


