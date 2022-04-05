//https://docs.microsoft.com/en-us/ef/core/

using Microsoft.EntityFrameworkCore;

namespace back_end 
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions<Context> options)
            : base(options) {}
    }
}