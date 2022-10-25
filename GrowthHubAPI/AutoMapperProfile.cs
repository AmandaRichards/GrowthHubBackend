using System;
using GrowthHubAPI.Dtos.Subject;
using GrowthHubAPI.Dtos.Resource;
using AutoMapper;
using GrowthHubAPI.Models;

namespace GrowthHubAPI
{
    public class AutoMapperProfile : Profile
    {
        
            public AutoMapperProfile()
            {
                CreateMap<Subject, GetSubjectDto>();
                CreateMap<AddSubjectDto, Subject>();
                CreateMap<UpdateSubjectDto, Subject>();
                CreateMap<Resource, GetResourceDto>();
                CreateMap<AddResourceDto, Resource>();
                CreateMap<UpdateResourceDto, Resource>();
            }
        }
    }


