using MediatR;

namespace CRUD_CQRS.Application.Commands.Tax
{
    public record DeleteTaxCommand(int Id) : IRequest<bool>;
}
