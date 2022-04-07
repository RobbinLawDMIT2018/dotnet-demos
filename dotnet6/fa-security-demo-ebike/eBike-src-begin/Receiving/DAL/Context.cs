using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Receiving;

namespace Receiving
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options) {}
	}
}