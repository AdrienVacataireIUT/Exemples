using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_EF.ModeleFluent
{
    class ContextFluent : DbContext
    {
        public ContextFluent() : base("name=Cours1ConnexionString2") 
        {
            Database.SetInitializer<ContextFluent>(new DropCreateDatabaseIfModelChanges<ContextFluent>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.Add(new ClientFluent());
            modelBuilder.Configurations.Add(new CompteClientFluent());
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CompteClient> CompteClients { get; set; }
    }
}
