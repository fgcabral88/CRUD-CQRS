using CRUD_CQRS.Application.Dtos.Tax;
using CRUD_CQRS.Application.Queries.Tax;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CQRS.Application.Handlers.Tax
{
    public class GetAllTaxesHandler : IRequestHandler<GetAllTaxesQuery, IEnumerable<TaxListDto>>
    {
        private readonly AppDbContext _context;

        public GetAllTaxesHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxListDto>> Handle(GetAllTaxesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Taxes
                .Select(t => new TaxListDto 
                { 
                    Id = t.Id,
                    Name = t.Name,
                    Value = t.Value 
                })
                .ToListAsync(cancellationToken);
        }
    }
}
