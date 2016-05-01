
CREATE VIEW [dbo].[TeacherStudentView]
AS 
SELECT u.[UserId] as TeacherUserId
      ,u.[FirstName] as TeacherFirstName
      ,u.[LastName] as TeacherLastName
      ,u.[AspNetUserId] TeacherAspNetUserId
	  ,au.[Email] as TeacherEmail
	  ,student.[UserId] as StudentUserId
      ,student.[FirstName] as StudentFirstName
      ,student.[LastName] as StudentLastName
      ,student.[AspNetUserId] StudentAspNetUserId
	  ,studentau.[Email] as StudentEmail
  FROM [dbo].[UserRelation] ur
  inner join [dbo].[User] u
	on u.UserId = ur.ParentUserId
  inner join [dbo].[AspNetUsers] au
  on u.[AspNetUserId] = au.[Id]
	inner join [dbo].[User] student
	on ur.ChildUserId = student.UserId
	left outer join dbo.AspNetUsers studentau
	on student.AspNetUserId = studentau.Id
  where u.[IsActive] = 1 and student.IsActive=1;