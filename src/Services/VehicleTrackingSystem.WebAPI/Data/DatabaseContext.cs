using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Entities;

namespace VehicleTrackingSystem.WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<VehicleRegistration> vehicleRegistrations { get; set; }
        public DbSet<VehicleLocation> vehicleLocations { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
    }
}
