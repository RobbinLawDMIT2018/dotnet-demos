using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Purchasing;

namespace Purchasing
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}
	}
}