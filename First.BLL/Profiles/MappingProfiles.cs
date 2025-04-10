using AutoMapper;
using First.BLL.DataTransferObjects.EmployeeDataTransferObject;
using First.DAL.Models.EmployeeModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace First.BLL.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmpGender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, Options => Options.MapFrom(src => src.Department.Name !=null ? src.Department.Name:null));

            CreateMap<Employee, EmployeeDetailsDto>()
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                 .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                  .ForMember(dest => dest.Department, Options => Options.MapFrom(src => src.Department.Name != null ? src.Department.Name : null))
                  .ForMember(dest => dest.Img, Options => Options.MapFrom(src => src.ImgName));



            CreateMap<CreatedEmployeeDto, Employee>()
                 .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
