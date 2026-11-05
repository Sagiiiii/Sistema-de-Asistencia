using SISAS.Application.Commons.Bases;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Dtos.Response;
using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Interfaces
{
    public interface IHorarioApplication
    {
        Task<BaseResponse<BaseEntityResponse<HorarioResponseDto>>> ListHorarios(BaseFiltersRequest filters);
        Task<BaseResponse<HorarioResponseDto>> HorarioById(int horarioId);
        Task<BaseResponse<bool>> RegisterHorario(HorarioRequestDto requestDto);
        Task<BaseResponse<bool>> EditHorario(int horarioId, HorarioRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveHorario(int horarioId);
    }
}
