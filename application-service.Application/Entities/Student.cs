using System;
using System.Collections.Generic;
using Application.Service.Application.Handlers;
using System.Linq;
using BoltOn.Exceptions;

namespace Application.Service.Application.Entities
{
	public class Student 
	{
		private List<StudentCourse> _courses = new List<StudentCourse>();		
		public virtual Guid StudentId { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Email { get;  set; }
		public virtual int StudentTypeId { get; set; }
		public virtual IReadOnlyCollection<StudentCourse> Courses { get { return _courses.AsReadOnly(); } }

		private Student()
		{
		}

		internal Student(CreateStudentRequest request, string studentType)
		{
			StudentId = Guid.NewGuid();
			FirstName = request.FirstName;
			LastName = request.LastName;
			StudentTypeId = request.StudentTypeId;
			Email = request.Email;
		}

		internal void Update(UpdateStudentRequest request, string studentType)
		{
			FirstName = request.FirstName;
			LastName = request.LastName;
			StudentTypeId = request.StudentTypeId;
			Email = request.Email;
		}

		internal void EnrollCourse(Guid courseId)
		{
			if (_courses.Any(a => a.CourseId == courseId))
				throw new BusinessValidationException("Course already enrolled");

			_courses.Add(new StudentCourse(StudentId, courseId));
		}
	}
}
