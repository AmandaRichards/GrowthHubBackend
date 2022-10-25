using System;
using GrowthHubAPI.Models;
using GrowthHubAPI.Dtos.Subject;

namespace GrowthHubAPI.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<ServiceResponse<List<GetSubjectDto>>> GetAllSubjects();

        Task<ServiceResponse<GetSubjectDto>> GetSubjectById(int id);

        Task<ServiceResponse<List<AddSubjectDto>>> AddSubjects(Subject newSubject);

        Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto updatedSubject);

        Task<ServiceResponse<List<GetSubjectDto>>> DeleteSubject(int id);
        Task<object?> AddSubjects(AddSubjectDto newSubject);
    }
}




