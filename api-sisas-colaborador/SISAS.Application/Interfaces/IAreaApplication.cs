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
    public interface IAreaApplication
    {
        Task<BaseResponse<BaseEntityResponse<AreaResponseDto>>> ListAreas(BaseFiltersRequest filters);
        Task<BaseResponse<AreaResponseDto>> AreaById(int areaId);
        Task<BaseResponse<bool>> RegisterArea(AreaRequestDto requestDto);
        Task<BaseResponse<bool>> EditArea(int areaId, AreaRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveArea(int areaId);
    }
}
