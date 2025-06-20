using CRUD_CQRS.Application.Commands.Tax;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;

namespace CRUD_CQRS.Application.Handlers.Tax
{
    public class UpdateTaxHandler : IRequestHandler<UpdateTaxCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateTaxHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            var tax = await _context.Taxes.FindAsync(request.Id);

            if (tax == null) 
                return false;

            tax.Name = request.Name;
            tax.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
