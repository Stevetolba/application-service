using AutoMapper;
using Application.Service.Application.DTOs;
using Application.Service.Application.Entities;

namespace Application.Service.Application
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Student, StudentDto>()
				.ForMember(d => d.Courses, o => o.Ignore());
			CreateMap<StudentFlattened, StudentDto>();
			CreateMap<Course, CourseDto>();
		}
	}
}
