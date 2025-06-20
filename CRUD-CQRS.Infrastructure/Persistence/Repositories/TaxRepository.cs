using CRUD_CQRS.Domain.Entities;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CQRS.Infrastructure.Persistence.Repositories
{
    public class TaxRepository
    {
        private readonly AppDbContext _context;

        public TaxRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxEntity>> GetAllAsync()
        {
            return await _context.Taxes.ToListAsync();
        }

        public async Task<TaxEntity?> GetByIdAsync(int id)
        {
            return await _context.Taxes.FindAsync(id);
        }

        public async Task<Guid> AddAsync(TaxEntity tax)
        {
            _context.Taxes.Add(tax);

            await _context.SaveChangesAsync();

            return tax.Id;
        }

        public async Task<bool> UpdateAsync(TaxEntity tax)
        {
            _context.Taxes.Update(tax);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(TaxEntity tax)
        {
            _context.Taxes.Remove(tax);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
