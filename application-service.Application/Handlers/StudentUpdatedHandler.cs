using System;
using System.Threading;
using System.Threading.Tasks;
using BoltOn.Data;
using BoltOn.Data.MartenDb;
using BoltOn.Requestor;
using Application.Service.Application.Entities;

namespace Application.Service.Application.Handlers
{
	public class StudentUpdatedEvent : IRequest
	{
		public Guid StudentId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string StudentType { get; set; }

		public int StudentTypeId { get; set; }
	}

	public class StudentUpdatedEventHandler : IHandler<StudentUpdatedEvent>
	{
		private readonly IRepository<StudentFlattened> _repository;

		public StudentUpdatedEventHandler(IRepository<StudentFlattened> repository)
		{
			_repository = repository;
		}

		public async Task HandleAsync(StudentUpdatedEvent request, CancellationToken cancellationToken)
		{
			var student = await _repository.GetByIdAsync(request.StudentId, cancellationToken: cancellationToken);
			student.Update(request);
			await _repository.UpdateAsync(student, cancellationToken: cancellationToken);
		}
	}
}