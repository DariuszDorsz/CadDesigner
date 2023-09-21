using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult CreateDesigner([FromBody] CreateDesignertDto dto)
        {
            var id = _designerService.Create(dto);

            return Created($"/api/designer/{id}", null);
        }

        [HttpGet]      
        public ActionResult<IEnumerable<DesignerDto>> GetAll([FromQuery] DesignerQuery query)
        {
            var designerDtos = _designerService.GetAll(query);

            return Ok(designerDtos);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDesignerDto dto, [FromRoute] int id)
        {

            _designerService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _designerService.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<DesignerDto> Get([FromRoute] int id)
        {
            var designer = _designerService.GetById(id);

            return Ok(designer);
        }
    }
}
