using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using About;

namespace About
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}

		public DbSet<BuildVersion> BuildVersions { get; set; }
	}
}