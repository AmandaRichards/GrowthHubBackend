using System;
namespace GrowthHubAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Table("Resource")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceId { get; set; }

        public string ResourceName { get; set; } = String.Empty;

        public string ResourceSubject { get; set; } = String.Empty;

       
        public string ResourceLink { get; set; } = String.Empty;


    }
}

//this matches web not prev project