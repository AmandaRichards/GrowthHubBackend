using System;
using AutoMapper;
using GrowthHubAPI;
using GrowthHubAPI.Dtos.Resource;
using GrowthHubAPI.Models;
using GrowthHubAPI.Context;
//using GrowthHubAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace GrowthHubAPI.Services.ResourceService
{
    public class ResourceService : IResourceService
    {

        private static List<Resource> resources = new List<Resource>
        {
            new Resource( ),
            new Resource{ ResourceName = "UX Design Video"}
        };

        private readonly IMapper _mapper;
        private readonly HubContext _context;

        public ResourceService(IMapper mapper, HubContext context) //dependency inject the data context to be available everywhere in character service
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetResourceDto>>> AddResources(AddResourceDto newResource)
        {
            var serviceResponse = new ServiceResponse<List<GetResourceDto>>();   //new instance of the service response class
            Resource resource = _mapper.Map<Resource>(newResource);
            //character.Id = characters.Max(c => c.Id) + 1; - DB now makes id for us 
            _context.Resources.Add(resource);//angle bracket is the type you are mapping to 
            await _context.SaveChangesAsync(); //writes the changes to db and writes new id
            serviceResponse.Data = await _context.Resources
                .Select(c => _mapper.Map<GetResourceDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public Task<ServiceResponse<List<AddResourceDto>>> AddResources(Resource newResource)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetResourceDto>>> DeleteResource(int id)
        {

            ServiceResponse<List<GetResourceDto>> response = new ServiceResponse<List<GetResourceDto>>();
            try
            {
                Resource resource = await _context.Resources.FirstAsync(c => c.ResourceId == id); //firstOrDefault returns null if nothing is found; first returns an exception 
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
                response.Data = resources.Select(c => _mapper.Map<GetResourceDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<ServiceResponse<List<GetResourceDto>>> GetAllResources()
        {
            var response = new ServiceResponse<List<GetResourceDto>>();
            var dbResourcess = await _context.Resources.ToListAsync();

            response.Data = resources.Select(c => _mapper.Map<GetResourceDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetResourceDto>> GetResourceById(int id)
        {
            var serviceResponse = new ServiceResponse<GetResourceDto>();
            var dbResource = await _context.Resources.FirstOrDefaultAsync(c => c.ResourceId == id);
            serviceResponse.Data = _mapper.Map<GetResourceDto>(dbResource);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetResourceDto>> UpdateResource(UpdateResourceDto updatedResource)
        {
            ServiceResponse<GetResourceDto> response = new ServiceResponse<GetResourceDto>();
            try
            {
                var resource = await _context.Resources
                    .FirstOrDefaultAsync(c => c.ResourceId == updatedResource.ResourceId); //made changes to character table so need to save



                _mapper.Map(updatedResource, resource);
                await _context.SaveChangesAsync();


                response.Data = _mapper.Map<GetResourceDto>(resource);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        Task<object?> IResourceService.AddResources(AddResourceDto newResource)
        {
            throw new NotImplementedException();
        }
    }

}





