using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Interfaces;
using SISAS.Infraestructure.Commons.Bases.Request;

namespace SISAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaApplication _areaApplication;
        public AreaController(IAreaApplication areaApplication)
        {
            _areaApplication = areaApplication;
        }
        [HttpPost]
        public async Task<IActionResult> ListArea([FromBody] BaseFiltersRequest filters)
        {
            var response = await _areaApplication.ListAreas(filters);
            return Ok(response);
        }
        [HttpGet("{areaId:int}")]
        public async Task<IActionResult> GetAreaById(int areaId)
        {
            var response = await _areaApplication.AreaById(areaId);
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterArea([FromBody] AreaRequestDto requestDto)
        {
            var response = await _areaApplication.RegisterArea(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{areaId:int}")]
        public async Task<IActionResult> EditArea(int areaId, [FromBody] AreaRequestDto requestDto)
        {
            var response = await _areaApplication.EditArea(areaId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{areaId:int}")]
        public async Task<IActionResult> RemoveArea(int areaId)
        {
            var response = await _areaApplication.RemoveArea(areaId);
            return Ok(response);
        }
    }
}
