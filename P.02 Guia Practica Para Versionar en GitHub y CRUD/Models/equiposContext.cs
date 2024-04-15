using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace P._02_Guia_Practica_Para_Versionar_en_GitHub_y_CRUD.Models
{
    public class equiposContext : DbContext
    {
        public equiposContext(DbContextOptions<equiposContext> options) : base(options)
        { }

        public DbSet<Equipos> equipos { get; set; }
    }
}
