using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ivDemo.Models;
using Microsoft.EntityFrameworkCore;
namespace ivDemo.Data
{
	public class SupplierContext:DbContext
	{
		public SupplierContext(DbContextOptions<SupplierContext> options):base(options)
		{
		}
		public DbSet<Supplier> Supplier
		{
			get;
			set;
		}
		public DbSet<SupplierType> SupplierType
		{
			get;
			set;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//个性化的DbContext表名
			modelBuilder.Entity<Supplier>().ToTable("Supplier");
			modelBuilder.Entity<SupplierType>().ToTable("SupplierType");
		}

	}
}
