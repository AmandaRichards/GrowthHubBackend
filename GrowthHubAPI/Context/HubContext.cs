using System;
using GrowthHubAPI.Models;

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
        public DbSet<Subject>? Subjects { get; set; }
    }
}

