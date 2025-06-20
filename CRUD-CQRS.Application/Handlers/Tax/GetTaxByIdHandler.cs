using CRUD_CQRS.Application.Dtos.Tax;
using CRUD_CQRS.Application.Queries.Tax;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;

namespace CRUD_CQRS.Application.Handlers.Tax
{
    public class GetTaxByIdHandler : IRequestHandler<GetTaxByIdQuery, TaxListDto>
    {
        private readonly AppDbContext _context;

        public GetTaxByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaxListDto> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
        {
            var tax = await _context.Taxes.FindAsync(request.Id);

            if (tax == null)
                throw new InvalidOperationException("Tax not found");

            return new TaxListDto
            {
                Id = tax.Id,
                Name = tax.Name,
                Value = tax.Value
            };
        }
    }
}
