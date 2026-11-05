using AutoMapper;
using FluentValidation;
using SISAS.Application.Commons.Bases;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Dtos.Response;
using SISAS.Application.Interfaces;
using SISAS.Application.Validators.Horario;
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
    public class HorarioApplication : IHorarioApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HorarioValidator _validationRules;

        public HorarioApplication(IUnitOfWork unitOfWork, IMapper mapper, HorarioValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;

        }

        public async Task<BaseResponse<bool>> EditHorario(int horarioId, HorarioRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var HorarioEdit = await HorarioById(horarioId);
            if (HorarioEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            var horario = _mapper.Map<PtHorario>(requestDto);
            horario.Id = horarioId;

            response.Data = await _unitOfWork.Horario.EditAsync(horario);
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

        public async Task<BaseResponse<HorarioResponseDto>> HorarioById(int horarioId)
        {
            var response = new BaseResponse<HorarioResponseDto>();
            var horario = await _unitOfWork.Horario.GetByIdAsync(horarioId);
            if (horario is not null)
            {

                response.IsSuccess = true;
                response.Data = _mapper.Map<HorarioResponseDto>(horario);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<HorarioResponseDto>>> ListHorarios(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<HorarioResponseDto>>();
            var horario = await _unitOfWork.Horario.ListHorarios(filters);
            if (horario is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<HorarioResponseDto>>(horario);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterHorario(HorarioRequestDto requestDto)
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
            var horario = _mapper.Map<PtHorario>(requestDto);
            response.Data = await _unitOfWork.Horario.RegisterAsync(horario);

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

        public async Task<BaseResponse<bool>> RemoveHorario(int horarioId)
        {
            var response = new BaseResponse<bool>();
            var horario = await HorarioById(horarioId);
            if (horario.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await _unitOfWork.Horario.RemoveAsync(horarioId);
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
