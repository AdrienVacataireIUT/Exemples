using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_EF.ModeleDA
{
    public class ContextDA : DbContext
    {
        public ContextDA() : base("name=Cours1ConnexionString") 
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CompteClient> CompteClients { get; set; }
    }
}
