using System.Collections.Generic;
using BoltOn.Data.EF;
using Application.Service.Application.Entities;
using Marten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Service.Infrastructure.Data.Mappings
{
	public class StudentMapping : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder
				.ToTable("Student")
				.HasKey(k => k.StudentId);
			builder
				.Property(p => p.StudentId)
				.HasColumnName("StudentId")
				.ValueGeneratedNever();
			builder
				.HasMany(p => p.Courses);
		}
	}
}
