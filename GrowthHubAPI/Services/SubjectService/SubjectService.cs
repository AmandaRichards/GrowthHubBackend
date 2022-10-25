using System;
using GrowthHubAPI;
using GrowthHubAPI.Dtos.Subject;
using GrowthHubAPI.Models;
using GrowthHubAPI.Context;
using GrowthHubAPI.Controllers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GrowthHubAPI.Services.SubjectService
{
    public class SubjectService: ISubjectService
    {

        private static List<Subject> subjects = new List<Subject>();
        

        private readonly IMapper _mapper;
        private readonly HubContext _context;

        public SubjectService(IMapper mapper, HubContext context) //dependency inject the data context to be available everywhere in character service
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetSubjectDto>>> AddSubjects(AddSubjectDto newSubject)
        {
            var serviceResponse = new ServiceResponse<List<GetSubjectDto>>();   //new instance of the service response class
            Subject subject = _mapper.Map<Subject>(newSubject);
            //character.Id = characters.Max(c => c.Id) + 1; - DB now makes id for us 
            _context.Subjects.Add(subject);//angle bracket is the type you are mapping to 
            await _context.SaveChangesAsync(); //writes the changes to db and writes new id
            serviceResponse.Data = await _context.Subjects
                .Select(c => _mapper.Map<GetSubjectDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public Task<ServiceResponse<List<AddSubjectDto>>> AddSubjects(Subject newSubject)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetSubjectDto>>> DeleteSubject(int id)
        {

            ServiceResponse<List<GetSubjectDto>> response = new ServiceResponse<List<GetSubjectDto>>();
            try
            {
                Subject subject = await _context.Subjects.FirstAsync(c => c.SubjectId == id); //firstOrDefault returns null if nothing is found; first returns an exception 
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                response.Data = subjects.Select(c => _mapper.Map<GetSubjectDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<ServiceResponse<List<GetSubjectDto>>> GetAllSubjects()
        {
            var response = new ServiceResponse<List<GetSubjectDto>>();
            var dbSubjects = await _context.Subjects.ToListAsync();

            response.Data = dbSubjects.Select(c => _mapper.Map<GetSubjectDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetSubjectDto>> GetSubjectById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSubjectDto>();
            var dbSubject = await _context.Subjects.FirstOrDefaultAsync(c => c.SubjectId == id);
            serviceResponse.Data = _mapper.Map<GetSubjectDto>(dbSubject);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto updatedSubject)
        {
            ServiceResponse<GetSubjectDto> response = new ServiceResponse<GetSubjectDto>();
            try
            {
                var subject = await _context.Subjects
                    .FirstOrDefaultAsync(c => c.SubjectId == updatedSubject.SubjectId); //made changes to character table so need to save



                _mapper.Map(updatedSubject, subject);
                await _context.SaveChangesAsync();
              

                response.Data = _mapper.Map<GetSubjectDto>(subject);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        Task<object?> ISubjectService.AddSubjects(AddSubjectDto newSubject)
        {
            throw new NotImplementedException();
        }
    }

}


    


