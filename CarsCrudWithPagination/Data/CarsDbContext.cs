using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarsCrudWithPagination.Models;

namespace CarsCrudWithPagination.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colors>().HasData(new List<Colors>()
            {
                new Colors()
                     {
                         ColorNo = 1,
                         ColorName = "Red",
                     }
                ,
                 new Colors()
                     {
                         ColorNo = 2,
                         ColorName = "Black",
                     },
                 new Colors()
                     {
                         ColorNo = 3,
                         ColorName = "Green",
                     },
            });

            modelBuilder.Entity<Car>().HasData(new List<Car>()
            {
                new Car()
                {
                    CarNo = 1,
                    UserNo = "1",
                    ArName = "اول اسم",
                    EnName = "First Name",
                    CardNo = "33",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Company = "Appy",
                    ColorNo =  1,
                    Model = "bmw"
                },
                new Car()
                {
                    CarNo = 2,
                    UserNo = "2",
                    ArName = "ثاني اسم",
                    EnName = "Second Name",
                    CardNo = "33",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    Company = "mg",
                    ColorNo =  2,
                    Model = "bmw"
                },
                new Car()
                {
                    CarNo = 3,
                    UserNo = "3",
                    ArName = "ثالث اسم",
                    EnName = "Third Name",
                    CardNo = "33",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(15),
                    Company = "mg-control.com",
                    ColorNo =  3,
                    Model = "mg"
                },
            });
           
        }
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Colors> Colors { get; set; } = default!;
    }
}
