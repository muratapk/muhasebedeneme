using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Brans
    {
        [Key]
        public int Brans_Id { get; set; }
        public string Brans_Adi { get; set; } = string.Empty;
    }
}
