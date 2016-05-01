CREATE VIEW GroupView
AS 
SELECT 
g.[GroupId]
,g.[GroupTypeId]
,g.[GroupName] as GroupName
,g.[IsActive]
,g.OwnerUserId
,gt.[GroupName] as GroupTypeName
  FROM [dbo].[GroupType] gt
  inner join [dbo].[Group] g
  on g.GroupTypeId = gt.GroupTypeId