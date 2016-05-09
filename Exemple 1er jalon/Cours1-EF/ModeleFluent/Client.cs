using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_EF.ModeleFluent
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Nom { get; set; }

        public ICollection<CompteClient> Comptes { get; set; }
    }

    public class ClientFluent : EntityTypeConfiguration<Client>
    {
        public ClientFluent()
        {
            ToTable("APP_Client");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CLI_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nom).HasColumnName("CLI_NOM").IsRequired().HasMaxLength(50);

            HasMany(c => c.Comptes).WithRequired(cc => cc.Client).HasForeignKey(cc => cc.ClientId);
        }
    }
}
