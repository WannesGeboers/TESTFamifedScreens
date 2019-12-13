
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TESTFamifedScreens.DAL.Entities;

namespace TESTFamifedScreens.DAL.Context
{
    public class FamifedDatabaseContext:DbContext
    {
        public FamifedDatabaseContext(DbContextOptions<FamifedDatabaseContext> options) : base(options)
        {
        }

        //tables
        public DbSet<FoodRequest> FoodRequests { get; set; }
        public DbSet<FlowStatus> FlowStatusMessages { get; set; }
        public DbSet<FoodOption> FoodOptions { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
