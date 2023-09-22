using CadDesigner.Aplication.DtoModels;
using CadDesigner.Aplication.Services;
using Microsoft.AspNetCore.Mvc;
using static CadDesigner.Aplication.Services.ServiceService;

namespace CadDesigner.Program.Controllers
{
    [Route("api/designer/{designerId}/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        [HttpPost]
        public ActionResult Post([FromRoute] int designerId, [FromBody] CreateServiceDto dto)
        {
            var newService = _serviceService.Create(designerId, dto);

            return Created($"api/designer/{designerId}/service/{newService}", null);
        }


        [HttpGet("{serviceId}")]
        public ActionResult<ServiceDto> Get([FromRoute] int designerId, [FromRoute] int serviceId)
        {
            var dish = _serviceService.GetById(designerId, serviceId);
            return Ok(dish);
        }


        [HttpDelete]
        public ActionResult Delete([FromRoute] int designerId)
        {
            _serviceService.RemoveAll(designerId);

            return NoContent();
        }


        [HttpGet]
        public ActionResult<List<ServiceDto>> Get([FromRoute] int restaurantId)
        {
            var result = _serviceService.GetAll(restaurantId);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int designerId, [FromRoute] int serviceId) 
        {
            _serviceService.Delete(designerId, serviceId);

            return NoContent();
        }

    }
}
