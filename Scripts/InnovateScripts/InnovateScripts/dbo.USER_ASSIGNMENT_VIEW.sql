Drop View UserAssignmentView;

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
	  ,ua.IsSubmitted
	  ,ua.SubmittedDate
	  ,ua.Grade
	  ,ua.GradeDescription
      ,a.[AssignmentTitle]
      ,a.[AssignmentDescription]
      ,a.[AssignmentSpanishTitle]
      ,a.[AssignmentSpanishDescription]
	  ,va.VocabularyId
	  ,at.AssignmentTypeTitle
  FROM [dbo].[Assignment] a
  inner join [dbo].[UserAssignment] ua
  on ua.AssignmentId = a.AssignmentId
  inner join [dbo].[User] u
  on u.UserId = ua.AssignedUserId
  inner join [dbo].[User] ut
  on ut.UserId = ua.AssigningUserId
  inner join [dbo].AssignmentType at
  on at.AssignmentTypeId = a.AssignmentTypeId
  left outer join [dbo].VocabularyAssignment va
  on va.UserAssignmentId = ua.UserAssignmentId
  where a.IsActive=1 AND ua.IsActive=1