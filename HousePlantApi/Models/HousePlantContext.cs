using System;
using Microsoft.EntityFrameworkCore;

namespace HousePlantApi.Models
{
    public class HousePlantContext : DbContext
    {
        public HousePlantContext(DbContextOptions<HousePlantContext> options) : base(options) { }

        public DbSet<HousePlantItem> HousePlantItems { get; set; }
    }
}
