using System;
using GrowthHubAPI.Dtos.Resource;
using GrowthHubAPI.Models;

namespace GrowthHubAPI.Services.ResourceService
{
    public interface IResourceService
    {
        Task<ServiceResponse<List<GetResourceDto>>> GetAllResources();

        Task<ServiceResponse<GetResourceDto>> GetResourceById(int id);

        Task<ServiceResponse<List<AddResourceDto>>> AddResources(Resource newResource);

        Task<ServiceResponse<GetResourceDto>> UpdateResource(UpdateResourceDto updatedResource);

        Task<ServiceResponse<List<GetResourceDto>>> DeleteResource(int id);
        Task<object?> AddResources(AddResourceDto newResource);
    }
}

