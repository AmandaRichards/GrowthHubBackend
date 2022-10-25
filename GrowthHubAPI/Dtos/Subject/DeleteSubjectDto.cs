using System;
namespace GrowthHubAPI.Dtos.Subject
{
    public class DeleteSubjectDto
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = String.Empty;

        public string SubjectImage { get; set; } = String.Empty;

        public List<string>? ResourceLink { get; set; }

    }
}

