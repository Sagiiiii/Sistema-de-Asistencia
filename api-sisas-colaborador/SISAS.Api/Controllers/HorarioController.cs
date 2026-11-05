using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Interfaces;
using SISAS.Infraestructure.Commons.Bases.Request;

namespace SISAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioApplication _horarioApplication;
        public HorarioController(IHorarioApplication horarioApplication)
        {
            _horarioApplication = horarioApplication;
        }
        [HttpPost]
        public async Task<IActionResult> ListHorario([FromBody] BaseFiltersRequest filters)
        {
            var response = await _horarioApplication.ListHorarios(filters);
            return Ok(response);
        }
        [HttpGet("{horarioId:int}")]
        public async Task<IActionResult> GetHorarioById(int horarioId)
        {
            var response = await _horarioApplication.HorarioById(horarioId);
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterHorario([FromBody] HorarioRequestDto requestDto)
        {
            var response = await _horarioApplication.RegisterHorario(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{horarioId:int}")]
        public async Task<IActionResult> EditHorario(int horarioId, [FromBody] HorarioRequestDto requestDto)
        {
            var response = await _horarioApplication.EditHorario(horarioId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{horarioId:int}")]
        public async Task<IActionResult> RemoveHorario(int horarioId)
        {
            var response = await _horarioApplication.RemoveHorario(horarioId);
            return Ok(response);
        }
    
}
}
