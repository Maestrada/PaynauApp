using PaynauApp_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PaynauApp_Infrastructure
{
    public class PaynauContext : DbContext
    {
        public PaynauContext(DbContextOptions<PaynauContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
    }
}
