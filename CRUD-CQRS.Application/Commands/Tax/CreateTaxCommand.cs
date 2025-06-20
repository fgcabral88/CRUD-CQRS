using MediatR;

namespace CRUD_CQRS.Application.Commands.Tax
{
    public record CreateTaxCommand(string Name, decimal Value) : IRequest<Guid>;
}
