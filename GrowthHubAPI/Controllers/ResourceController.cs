using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrowthHubAPI.Dtos.Resource;
using GrowthHubAPI.Services.ResourceService;
using GrowthHubAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthHubAPI.Controllers



{
    [ApiController] //attribute indicates that type and all derived types are used to serve API responses
    [Route("api/[controller]")] // route attribute
    public class ResourceController : ControllerBase //base class for MVC controller
    {
        private readonly IResourceService _resourceService;
        public ResourceController(IResourceService resourceService) //dependency injection 
        {
            _resourceService = resourceService;
        }

        //Iaction result allows to send specific HTTP status codes along with actual data requested by the client this goes to character/GetAll
        //[HttpGet]
        //[Route("GetAll")]
        [HttpGet("GetAll")] //simplified version 
        //routing is required once there are two get methods otherwise api doesn't know which to use
        public async Task<ActionResult<ServiceResponse<List<GetResourceDto>>>> Get()
        {
            return Ok(await _resourceService.GetAllResources()); //SENDS status 200 ok along with mock character
        }

        [HttpGet("{id}")] //value in squiggles has to match the parameter below
        public async Task<ActionResult<ServiceResponse<List<GetResourceDto>>>> GetSingle(int id)
        {
            return Ok(await _resourceService.GetResourceById(id)); //SENDS status 200 ok along with mock character
        }

        [HttpDelete("{id}")] //value in squiggles has to match the parameter below
        public async Task<ActionResult<ServiceResponse<List<GetResourceDto>>>> Delete(int id)
        {
            var response = await _resourceService.DeleteResource(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost] //these are attributes

        public async Task<ActionResult<ServiceResponse<List<GetResourceDto>>>> AddResource(AddResourceDto newResource)
        {
            return Ok(await _resourceService.AddResources(newResource));

        }

        [HttpPut] //these are attributes

        public async Task<ActionResult<ServiceResponse<GetResourceDto>>> UpdateResource(UpdateResourceDto updatedResource)
        {
            var response = await _resourceService.UpdateResource(updatedResource);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
    }
}




