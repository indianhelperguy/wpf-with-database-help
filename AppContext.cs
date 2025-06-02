using ECDL_Megoldas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDL_Megoldas
{
    public class AppContext : DbContext
    {
        public DbSet<Vizsgazo> Vizsgazok { get; set; }
        public DbSet<Vizsgatipus> Vizsgatipus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=ecdl;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=ecdl;Uid=root;Pwd=;"));
        }

    }
}
