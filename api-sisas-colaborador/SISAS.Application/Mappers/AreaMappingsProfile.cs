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
    public class AreaMappingsProfile : Profile
    {
        public AreaMappingsProfile()
        {
            CreateMap<PtArea, AreaResponseDto>()
                .ForMember(x => x.IdArea, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateCategory, x => x.MapFrom(y =>
                    y.Estado == (int)StateTypes.Active
                        ? "Activo"
                        : "Inactivo"
                ));

            CreateMap<BaseEntityResponse<PtArea>, BaseEntityResponse<AreaResponseDto>>();

            CreateMap<AreaRequestDto, PtArea>()
                .ForMember(x => x.CreatedAt, x => x.Ignore())
                .ForMember(x => x.DeletedAt, x => x.Ignore())
                .ForMember(x => x.Id, x => x.Ignore());
        }
    }
}
