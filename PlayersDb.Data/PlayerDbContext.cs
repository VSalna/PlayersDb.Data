using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace PlayersDb.Data
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext()
        {

        }
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB;
                AttachDbFilename = C:\Users\viest\source\repos\rcs2309\PlayersDb.Data\PlayersDb.Data\PlayersDb.mdf;
                Integrated Security = True;
                Connect Timeout = 30");
            }

            base.OnConfiguring(optionsBuilder);
            
    }
    public DbSet<Player> PlayersStats { get; set; }
        
    }
}