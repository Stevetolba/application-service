using Application.Service.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using BoltOn.Data.EF;

namespace Application.Service.Infrastructure.Data
{
	public class SchoolDbContext : DbContext
	{
		public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromNamespaceOfType<StudentMapping>();
		}
    }
}
