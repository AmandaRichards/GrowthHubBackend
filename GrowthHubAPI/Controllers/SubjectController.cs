using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowthHubAPI.Dtos.Subject;
using GrowthHubAPI.Models;
using GrowthHubAPI.Services.SubjectService;
using Microsoft.AspNetCore.Mvc;
//using dotnet_rpg.Dtos.Character;
//using dotnet_rpg.Services.CharacterService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrowthHubAPI.Controllers

{
    [ApiController] //attribute indicates that type and all derived types are used to serve API responses
    [Route("api/[controller]")] // route attribute
    public class SubjectController : ControllerBase //base class for MVC controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService) //dependency injection 
        {
            _subjectService = subjectService;
        }

        //Iaction result allows to send specific HTTP status codes along with actual data requested by the client this goes to character/GetAll
        //[HttpGet]
        //[Route("GetAll")]
        [HttpGet("GetAll")] //simplified version 
        //routing is required once there are two get methods otherwise api doesn't know which to use
        public async Task<ActionResult<ServiceResponse<List<GetSubjectDto>>>> Get()
        {
            return Ok(await _subjectService.GetAllSubjects()); //SENDS status 200 ok along with mock character
        }

        [HttpGet("{id}")] //value in squiggles has to match the parameter below
        public async Task<ActionResult<ServiceResponse<List<GetSubjectDto>>>> GetSingle(int id)
        {
            return Ok(await _subjectService.GetSubjectById(id)); //SENDS status 200 ok along with mock character
        }

        [HttpDelete("{id}")] //value in squiggles has to match the parameter below
        public async Task<ActionResult<ServiceResponse<List<GetSubjectDto>>>> Delete(int id)
        {
            var response = await _subjectService.DeleteSubject(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost] //these are attributes

        public async Task<ActionResult<ServiceResponse<List<GetSubjectDto>>>> AddSubject(AddSubjectDto newSubject)
        {
            return Ok(await _subjectService.AddSubjects(newSubject));

        }

        [HttpPut] //these are attributes

        public async Task<ActionResult<ServiceResponse<GetSubjectDto>>> UpdateSubject(UpdateSubjectDto updatedSubject)
        {
            var response = await _subjectService.UpdateSubject(updatedSubject);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
    }
}


