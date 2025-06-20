using CRUD_CQRS.Application.Commands.Tax;
using CRUD_CQRS.Domain.Entities;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;

namespace CRUD_CQRS.Application.Handlers.Tax
{
    public class CreateTaxHandler : IRequestHandler<CreateTaxCommand, Guid>
    {
        private readonly AppDbContext _context;

        public CreateTaxHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var tax = new TaxEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Value = request.Value
            };

            _context.Taxes.Add(tax);

            await _context.SaveChangesAsync(cancellationToken);

            return tax.Id;
        }
    }
}
