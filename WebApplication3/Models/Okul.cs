using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Okul
    {
        [Key]
        public int OkulId { get; set; }
        public string OkulAdi { get; set; } = string.Empty;
        public int VergiNo { get; set; }

        
        public int ? MilceId { get; set; }
	
		
		public virtual Milce? Milce { get; set; }
		
		public virtual List<Maliyet>? Maliyets { get; set; }

    }
}
