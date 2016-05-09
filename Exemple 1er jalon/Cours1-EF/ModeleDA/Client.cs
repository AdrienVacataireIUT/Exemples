using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_EF.ModeleDA
{
    [Table("APP_Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CLI_ID")]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Column("CLI_NOM")]
        public string Nom { get; set; }

        public ICollection<CompteClient> Comptes { get; set; }
    }
}
