using CnabImporter.Application.Queries.GetStores;
using CnabImporter.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnabImporter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Get stores with balances
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetStores([FromQuery] int offset = 0, [FromQuery] int limit = 50)
        {
            var query = new GetStoresQuery(offset, limit);

            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}