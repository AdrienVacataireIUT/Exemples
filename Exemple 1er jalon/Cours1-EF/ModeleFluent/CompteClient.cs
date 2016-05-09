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
    public class CompteClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string NumeroCompte { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public string NomBanque { get; set; }
    }

    public class CompteClientFluent : EntityTypeConfiguration<CompteClient>
    {
        public CompteClientFluent()
        {
            ToTable("APP_CompteClient");
            HasKey(cc => cc.Id);

            Property(cc => cc.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(cc => cc.NumeroCompte).HasColumnName("NumeroCompte").IsRequired().HasMaxLength(10);
            Ignore(cc => cc.NomBanque);

            HasRequired(cc => cc.Client).WithMany(c => c.Comptes).HasForeignKey(c => c.ClientId);
        }
    }
}
