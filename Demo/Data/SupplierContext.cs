using Demo.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
	public class SupplierContext:DbContext
	{
		public SupplierContext(DbContextOptions<SupplierContext> options) : base(options)
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
			modelBuilder.Entity<SupplierType>(entity =>
			{
				entity.HasKey(e => e.TypeCode);
				entity.HasMany(c => c.Supplier).WithOne(a => a.SupplierType);//定义一对多的关系
			});
			modelBuilder.Entity<Supplier>(entity =>
			{
				entity.HasKey(e => e.SupplierID);
			});
		}
	}
}
