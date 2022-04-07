using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Sales;

namespace Sales
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}
	}
}