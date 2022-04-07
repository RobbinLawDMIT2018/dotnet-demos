using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Security;

namespace Security
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}

		public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
	}
}