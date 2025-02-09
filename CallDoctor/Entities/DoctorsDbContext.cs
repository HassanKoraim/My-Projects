using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.City)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            //Seed to Countries
            string citiesJson = System.IO.File.ReadAllText("Cities.json");
            List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(citiesJson);

            foreach (City city in cities)
                modelBuilder.Entity<City>().HasData(city);


            //Seed to Persons
            string doctorsJson = System.IO.File.ReadAllText("Doctors.json");
            List<Doctor> doctors = System.Text.Json.JsonSerializer.Deserialize<List<Doctor>>(doctorsJson);

            foreach (Doctor doctor in doctors)
                modelBuilder.Entity<Doctor>().HasData(doctor);
        }
        public List<Doctor> sp_GetAllDoctors()
        {
            return Doctors.FromSqlRaw("EXECUTE [dbo].[GetAllDoctors]").ToList();
        }
        public int sp_AddDoctor(Doctor doctor)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@DoctorId" , doctor.DoctorId),
               new SqlParameter("@DoctorName" , doctor.DoctorName),
               new SqlParameter("@CityId" , doctor.CityId),
               new SqlParameter("@Specialization" , doctor.Specialization),
               new SqlParameter("@ExaminationPrice" , doctor.ExaminationPrice),
               new SqlParameter("@Address" , doctor.Address),
               new SqlParameter("@PhoneNumber" , doctor.PhoneNumber),
            };
            return Database.ExecuteSqlRaw("EXECUTE [dbo].[AddDoctor] @DoctorId , @DoctorName ,@CityId , @Specialization , @ExaminationPrice ,@Address , @PhoneNumber ",parameters);
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");

            //Seed to Countries
            string citiesJson = System.IO.File.ReadAllText("Cities.json");
            List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(citiesJson);

            foreach (City city in cities)
                modelBuilder.Entity<City>().HasData(city);


            //Seed to Persons
            string doctorsJson = System.IO.File.ReadAllText("Doctors.json");
            List<Doctor> doctors = System.Text.Json.JsonSerializer.Deserialize<List<Doctor>>(doctorsJson);

            foreach (Doctor doctor in doctors)
                modelBuilder.Entity<Doctor>().HasData(doctor);
        }*/
    }
}