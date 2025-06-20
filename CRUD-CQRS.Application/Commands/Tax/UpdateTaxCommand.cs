using MediatR;

namespace CRUD_CQRS.Application.Commands.Tax
{
    public record UpdateTaxCommand(int Id, string Name, decimal Value) : IRequest<bool>;
}
