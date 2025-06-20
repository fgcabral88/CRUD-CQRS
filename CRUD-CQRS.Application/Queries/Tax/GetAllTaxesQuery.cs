using CRUD_CQRS.Application.Dtos.Tax;
using MediatR;

namespace CRUD_CQRS.Application.Queries.Tax
{
    public record GetAllTaxesQuery() : IRequest<IEnumerable<TaxListDto>>;
}
