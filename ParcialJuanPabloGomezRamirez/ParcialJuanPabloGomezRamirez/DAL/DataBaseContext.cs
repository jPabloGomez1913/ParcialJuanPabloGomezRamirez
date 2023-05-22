

using Microsoft.EntityFrameworkCore;
using ParcialJuanPabloGomezRamirez.DAL.Entities;
using System.Diagnostics.Metrics;

namespace ParcialJuanPabloGomezRamirez.DAL
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        private DbSet<Ticket> Tickets { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }*/
    }
}
