using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadDesigner.Program.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignersController : ControllerBase
    {
        private readonly IDesignerService _designerService;

        public DesignersController(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDesigner([FromBody] CreateDesignertDto dto)
        {
            var id = await _designerService.Create(dto);

            return Created($"/api/designer/{id}", null);
        }

        [HttpGet]      
        public async Task<ActionResult<IEnumerable<DesignerDto>>> GetAll([FromQuery] DesignerQuery query)
        {
            var designerDtos = await _designerService.GetAll(query);

            return Ok(designerDtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateDesignerDto dto, [FromRoute] int id)
        {

            await _designerService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _designerService.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesignerDto>> Get([FromRoute] int id)
        {
            var designer = await _designerService.GetById(id);

            return Ok(designer);
        }
    }
}
