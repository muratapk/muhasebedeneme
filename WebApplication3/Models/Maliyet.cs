using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Maliyet
    {
        [Key]
        public int Maliyet_Id { get; set; }
        public string isin_Adi { get; set; }
        public int isin_Adedi { get; set; }
        public decimal Tutari { get; set; }
        public decimal pesin_Gelir { get; set; }
        public decimal kar { get; set; }
        public decimal idari_pay { get; set; }
        public decimal shcek { get; set; }
        public decimal iscilik { get; set; }
        public decimal malzeme { get; set; }
        public decimal ogretmen { get; set; }
        public decimal ogrenci { get; set; }
       
        public int Okul_Id { get; set; }
        public virtual Okul? Okul { get; set; }

    }
}
