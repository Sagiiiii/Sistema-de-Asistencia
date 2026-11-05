using AutoMapper;
using SISAS.Application.Commons.Bases;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Dtos.Response;
using SISAS.Application.Interfaces;
using SISAS.Application.Validators.Area;
using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Request;
using SISAS.Infraestructure.Commons.Bases.Response;
using SISAS.Infraestructure.Persistences.Interfaces;
using SISAS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Services
{
    public class AreaApplication : IAreaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AreaValidator _validationRules;
        public AreaApplication(IUnitOfWork unitOfWork, IMapper mapper, AreaValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;

        }
        public async Task<BaseResponse<AreaResponseDto>> AreaById(int areaId)
        {
            var response = new BaseResponse<AreaResponseDto>();
            var area = await _unitOfWork.Area.GetByIdAsync(areaId);
            if (area is not null)
            {

                response.IsSuccess = true;
                response.Data = _mapper.Map<AreaResponseDto>(area);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditArea(int areaId, AreaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var areaEdit = await AreaById(areaId);
            if(areaEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            var area = _mapper.Map<PtArea>(requestDto);
            area.Id = areaId;
            
            response.Data = await _unitOfWork.Area.EditAsync(area);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<AreaResponseDto>>> ListAreas(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<AreaResponseDto>>();
            var area = await _unitOfWork.Area.ListAreas(filters);
            if(area is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<AreaResponseDto>>(area);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterArea(AreaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = _validationRules.Validate(requestDto);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            var area = _mapper.Map<PtArea>(requestDto);
            response.Data = await _unitOfWork.Area.RegisterAsync(area);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveArea(int areaId)
        {
            var response = new BaseResponse<bool>();
            var category = await AreaById(areaId);
            if(category.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await _unitOfWork.Area.RemoveAsync(areaId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
    }
}
