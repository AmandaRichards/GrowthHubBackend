﻿using System;
namespace GrowthHubAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Table("Subjects")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        public string Name { get; set; } = String.Empty;

        public string IconURL { get; set; } = String.Empty;

      
        //public List<string>? ResourceLink { get; set; }

    }
}

