using System;
using GrowthHubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowthHubAPI.Context
{
    using Microsoft.EntityFrameworkCore;
    //using Microsoft.WebApiCoreWithEF.Models;

    public class HubContext
        :DbContext
    {
        public HubContext(DbContextOptions options)
            : base(options)
        {
        }
        //public DbSet<Subject>? Subjects { get; set; }
        //public DbSet<Resource> Resources { get; set; }
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Resource> Resources => Set<Resource>();
    }
}
