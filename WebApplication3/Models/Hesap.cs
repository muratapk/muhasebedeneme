using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Hesap
    {
        [Key]
        public int Hesap_Id { get; set; }
        public int Maliyet_Id { get; set; }
        public int Personel_Id { get; set; }
        public int Adet { get; set; }
        public  virtual Personel Personel { get; set; }
        public virtual Maliyet Maliyet { get; set; }
    }
}
