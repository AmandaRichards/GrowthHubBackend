using System;
namespace GrowthHubAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = String.Empty;

        public string SubjectImage { get; set; } = String.Empty;

        public List<string>? ResourceLink { get; set; }

    }
}

