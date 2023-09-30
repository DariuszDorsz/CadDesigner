using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadDesigner.Program.Controllers
{
    [Route("api/service/{designerId}/")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromRoute] int designerId, [FromBody] CreateServiceDto dto)
        {
            var newService = await _serviceService.Create(designerId, dto);

            return Created($"api/designer/{designerId}/service/{newService}", null);
        }


        [HttpGet("{serviceId}")]
        public async Task<ActionResult<ServiceDto>> Get([FromRoute] int designerId, [FromRoute] int serviceId)
        {
            var dish = await _serviceService.GetById(designerId, serviceId);
            return Ok(dish);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteAll([FromRoute] int designerId)
        {
            await _serviceService.RemoveAll(designerId);

            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAll([FromRoute] int designerId)
        {
            var result = await _serviceService.GetAll(designerId);
            return Ok(result);
        }


        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> Delete([FromRoute] int designerId, [FromRoute] int serviceId) 
        {
            await _serviceService.Delete(designerId, serviceId);

            return NoContent();
        }

    }
}
