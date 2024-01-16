using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Personel
    {
        [Key]
        public int Personel_Id { get; set; }
        public string AdSoyad { get; set; }
        public int TcNo { get; set; }

        public  string  Iban { get; set; }
        public int Brans_Id { get; set; }
        public virtual Brans Brans { get; set; }
        public virtual ICollection<Hesap> Hesap { get; set; }

    }
}
