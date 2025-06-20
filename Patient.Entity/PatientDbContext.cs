﻿using Microsoft.EntityFrameworkCore;
using PatientApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Entity
{
    public class PatientDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PatientDbContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<Patients> Patients { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patients>()
                .Property(p => p.Id) // Assume PatientID is the identity column
                .ValueGeneratedOnAdd();      // Ensures that the value is auto-generated
        }
    }
}
