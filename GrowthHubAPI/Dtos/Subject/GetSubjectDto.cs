using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowthHubAPI.Dtos.Subject
{
    public class GetSubjectDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        public string Name { get; set; } = String.Empty;

        public string IconURL { get; set; } = String.Empty;

        //public List<string>? ResourceLink { get; set; }

    }
}

