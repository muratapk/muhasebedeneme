using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string AdSoyad { get; set; } = string.Empty; 
        public int? TcNo { get; set; }

        public string Iban { get; set; } = string.Empty;
        public int BransId { get; set; }
        [NotMapped]
        public virtual  Brans? Brans { get; set; }
		[NotMapped]
		public virtual  List<Hesap>? Hesap { get; set; }

    }
}
