using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Servicing;

namespace Servicing
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}
	}
}