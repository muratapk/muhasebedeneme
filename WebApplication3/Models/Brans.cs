using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Brans
    {
        [Key]
        public int Brans_Id { get; set; }
        public string Brans_Adi { get; set; } = string.Empty;
        [NotMapped]
        public virtual  List<Personel>? Personels { get; set; }
    }
}
