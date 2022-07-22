using AutoMapper;
using UMS.Application1.DTO;
using UMS.Domain.Models;

namespace UMS.Application1;


public class MapperReg : Profile
{
    public MapperReg()
    {
        /* CreateMap<CourseCreate, Domain.Models.Course>()
             .ForMember(
                 dest => dest.EnrolmentDateRange.Value.LowerBound,
                 opt => opt.MapFrom(src => src.)
             )
             .ForMember(
                 dest => dest.EnrolmentDateRange.Value.UpperBound,
                 opt => opt.MapFrom(src => $"{src.end}")
             );*/

        CreateMap<Domain.Models.User, UserCreate>()
            .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role.Name)
            );

        CreateMap<Domain.Models.Course, CourseCreate>()
            .ForMember(
                dest => dest.start,
                opt => opt.MapFrom(src =>
                    src.EnrolmentDateRange.Value.LowerBound.ToDateTime(TimeOnly.Parse("12:00 AM")))

            )
            .ForMember(
                dest => dest.end,
                opt => opt.MapFrom(src =>
                    src.EnrolmentDateRange.Value.UpperBound.ToDateTime(TimeOnly.Parse("12:00 AM")))

                );



    }
}