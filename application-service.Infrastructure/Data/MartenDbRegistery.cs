using System;
using Application.Service.Application.Entities;
using Marten;

namespace Application.Service.Infrastructure.Data
{
	public class MartenDbRegistery :MartenRegistry
	{
		public MartenDbRegistery()
		{
			For<Student>()
				.Identity(x => x.StudentId);
			//.DatabaseSchemaName("Student");

			For<StudentType>()
				.Identity(x => x.StudentTypeId);
				//.DatabaseSchemaName("StudentType");

        }
	}
}

