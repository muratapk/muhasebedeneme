using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Maliyet
    {
        [Key]
        public int MaliyetId { get; set; }
        public string Isin_Adi { get; set; } = string.Empty;
        public int Isin_Adedi { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Tutari { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Pesin_Gelir { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Kar { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Idari_pay { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Shcek { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Iscilik { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Malzeme { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Ogretmen { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Ogrenci { get; set; }

     
        public int OkulId { get; set; }
        public virtual Okul? Okul { get; set; }
        public virtual  List<Hesap>? Hesaps { get; set; }   

    }
}
