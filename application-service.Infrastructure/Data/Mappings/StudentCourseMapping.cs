using Application.Service.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Service.Infrastructure.Data.Mappings
{
    public class StudentCourseMapping : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder
                   .ToTable("StudentCourse")
                   .HasKey(k => k.StudentCourseId);
            builder
                .Property(p => p.StudentCourseId)
                .HasColumnName($"StudentCourseId")
                .ValueGeneratedNever();
        }
    }
}
