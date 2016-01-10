CREATE VIEW UserGroupView
AS 
SELECT 
UserGroupViewId = ROW_NUMBER() OVER   (ORDER BY u.[UserId], g.[GroupName] ASC)
,u.[UserId]
,u.[FirstName]
,u.[LastName]
,ug.[UserGroupId]
,g.[GroupId]
,g.[GroupTypeId]
,g.[GroupName] as GroupName
  FROM [dbo].[User] u
  inner join [dbo].[UserGroup] ug
  on u.UserId = ug.UserId
  inner join [dbo].[Group] g
  on ug.GroupId = g.GroupId
  where u.IsActive=1 AND ug.IsActive=1 AND g.IsActive=1