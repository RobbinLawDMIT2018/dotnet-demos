using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Security;

namespace Security
{
	public static class BackendExtensions
	{
		public static void AddSecurityDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
		{
			services.AddDbContext<Context>(options);
			services.AddTransient<Services>((serviceProvider) =>
			{
				var context = serviceProvider.GetRequiredService<Context>();
				return new Services(context);
			});
		}
	}
}
