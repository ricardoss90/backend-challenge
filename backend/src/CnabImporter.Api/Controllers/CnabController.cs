using CnabImporter.Application.Commands.ImportCnab;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CnabImporter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CnabController(IMediator mediator, ILogger<CnabController> logger) : ControllerBase
    {
        private readonly ILogger<CnabController> _logger = logger;

        /// <summary>
        /// Upload a CNAB file to import transactions
        /// </summary>
        [HttpPost("import")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> ImportCnabFile(IFormFile file)
        {
            if (file.Length == 0)
                return BadRequest("File is empty.");

            string content;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                content = await reader.ReadToEndAsync();
            }

            var command = new ImportCnabCommand(content, file.FileName);
            var result = await mediator.Send(command);

            if (!result)
                return BadRequest("Failed to import CNAB file.");

            return Ok(new { Message = "CNAB file imported successfully!" });
        }
    }
}