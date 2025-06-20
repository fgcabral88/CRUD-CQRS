using CRUD_CQRS.Application.Commands.Tax;
using CRUD_CQRS.Application.Dtos.Tax;
using CRUD_CQRS.Application.Queries.Tax;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TaxController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaxController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retorna todos os impostos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retorna todos os impostos")]
    [ProducesResponseType(typeof(IEnumerable<TaxListDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllTaxesQuery());

        return Ok(result);
    }

    /// <summary>
    /// Retorna um imposto por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retorna um imposto por ID")]
    [ProducesResponseType(typeof(TaxListDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetTaxByIdQuery(id));

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Cria um novo imposto
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Cria um novo imposto")]
    [ProducesResponseType(typeof(int), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Create([FromBody] CreateTaxCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    /// <summary>
    /// Atualiza um imposto
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza um imposto")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaxCommand command)
    {
        if (id != command.Id)
            return BadRequest("O ID da URL não coincide com o corpo da requisição.");

        var success = await _mediator.Send(command);

        return success ? Ok() : NotFound();
    }

    /// <summary>
    /// Remove um imposto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remove um imposto")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteTaxCommand(id));

        return success ? Ok() : NotFound();
    }
}
