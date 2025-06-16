using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Entity
{
    //public class PatientDbContextFactory 
    //{
    //    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    //    public PatientDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    //    {
    //        _configureDbContext = configureDbContext;
    //    }

    //    public PatientDbContext CreateDbContext()
    //    {
    //        DbContextOptionsBuilder<PatientDbContext> options = new DbContextOptionsBuilder<PatientDbContext>();

    //        _configureDbContext(options);

    //        return new PatientDbContext(options.Options);
    //    }

    //}

    public class PatientDbContextFactory : IDesignTimeDbContextFactory<PatientDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;
        string connectionString = "Server=Chinnari\\SQLEXPRESS;Database=PatientData;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"; // Or fetch from environment/config

        // This constructor is used at runtime, where the configuration is passed in via DI.
        public PatientDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        // Parameterless constructor for design-time (required by EF Core migrations)
        public PatientDbContextFactory()
        {
        }

        // This is the runtime method to create the context
        public PatientDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<PatientDbContext> options = new DbContextOptionsBuilder<PatientDbContext>();
            _configureDbContext?.Invoke(options);
            return new PatientDbContext(options.Options);
        }

        // This method is used by EF Core at design-time (e.g., for migrations)
        public PatientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientDbContext>();

            // Provide a fallback connection string or use environment variables

            optionsBuilder.UseSqlServer(connectionString);

            return new PatientDbContext(optionsBuilder.Options);
        }
    }


}
