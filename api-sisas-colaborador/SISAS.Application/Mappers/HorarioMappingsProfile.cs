using AutoMapper;
using SISAS.Application.Dtos.Request;
using SISAS.Application.Dtos.Response;
using SISAS.Domain.Entities.BD_EMPLEADO;
using SISAS.Infraestructure.Commons.Bases.Response;
using SISAS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Mappers
{
    public class HorarioMappingsProfile : Profile
    {

        public HorarioMappingsProfile()
        {
            CreateMap<PtHorario, HorarioResponseDto>()
                .ForMember(x => x.IdHorario, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateHorario, x => x.MapFrom(y =>
                    y.Estado == (int)StateTypes.Active
                        ? "Activo"
                        : "Inactivo"
                ));

            CreateMap<BaseEntityResponse<PtHorario>, BaseEntityResponse<HorarioResponseDto>>();

            CreateMap<HorarioRequestDto, PtHorario>()
                .ForMember(x => x.CreatedAt, x => x.Ignore())
                .ForMember(x => x.DeletedAt, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore());
        }
    }
}
