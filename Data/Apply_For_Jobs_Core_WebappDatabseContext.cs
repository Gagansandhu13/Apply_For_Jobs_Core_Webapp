using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;

namespace Apply_For_Jobs_Core_Webapp.Models
{
    //The databse context responsible for connecting to the databse and mapping the business layer classes.
    public class Apply_For_Jobs_Core_WebappDatabseContext : DbContext
    {
        public Apply_For_Jobs_Core_WebappDatabseContext (DbContextOptions<Apply_For_Jobs_Core_WebappDatabseContext> options)
            : base(options)
        {
        }

        public DbSet<Apply_For_Jobs_Core_Webapp.BusinessLayer.Advertisement> Advertisement { get; set; }

        public DbSet<Apply_For_Jobs_Core_Webapp.BusinessLayer.Application> Application { get; set; }

        public DbSet<Apply_For_Jobs_Core_Webapp.BusinessLayer.Candidate> Candidate { get; set; }

        public DbSet<Apply_For_Jobs_Core_Webapp.BusinessLayer.Employer> Employer { get; set; }
    }
}
