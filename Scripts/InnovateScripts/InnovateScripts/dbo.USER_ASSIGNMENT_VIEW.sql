CREATE VIEW UserAssignmentView
AS
SELECT 
	  ua.[UserAssignmentId]
	  ,u.[UserId]
	  ,u.[FirstName]
      ,u.[LastName]
	  ,a.[AssignmentId]
      ,a.[AssignmentTypeId]
      ,a.[AssignmentParentId]
      ,a.[DueDate]
      ,a.[AssignmentTitle]
      ,a.[AssignmentDescription]
      ,a.[AssignmentSpanishTitle]
      ,a.[AssignmentSpanishDescription]
  FROM [dbo].[Assignment] a
  inner join [dbo].[UserAssignment] ua
  on ua.AssignmentId = a.AssignmentId
  inner join [dbo].[User] u
  on u.UserId = ua.AssignedUserId
  inner join [dbo].[User] ut
  on ut.UserId = ua.AssigningUserId
  where a.IsActive=1 AND ua.IsActive=1