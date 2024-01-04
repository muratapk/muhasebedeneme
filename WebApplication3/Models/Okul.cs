using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Okul
    {
        [Key]
        public int Okul_Id { get; set; }
        public string OkulAdi { get; set; } = string.Empty;
        public int VergiNo { get; set; }
        
        public int ilce_Id { get; set; }

    }
}
