using CRUD_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CQRS.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<TaxEntity> Taxes => Set<TaxEntity>();
    }
}
