using CRUD_CQRS.Application.Commands.Tax;
using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;

namespace CRUD_CQRS.Application.Handlers.Tax
{
    public class DeleteTaxHandler : IRequestHandler<DeleteTaxCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteTaxHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            var tax = await _context.Taxes.FindAsync(request.Id);

            if (tax == null) 
                return false;

            _context.Taxes.Remove(tax);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
