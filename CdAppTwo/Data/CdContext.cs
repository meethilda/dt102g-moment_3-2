using System;
using CdAppTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace CdAppTwo.Data
{
    public class CdContext : DbContext
    {
        public DbSet<Cd> CDs { get; set; }

        public DbSet<Songs> Songs { get; set; }

        public CdContext(DbContextOptions<CdContext> options) : base(options)
        {
        }
    }
}
