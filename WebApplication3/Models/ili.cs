using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ili
    {
        [Key]
        public int il_Id { get; set; }
        public string il_Adi { get; set; } = string.Empty;
        public virtual List<ilcesi> ilcesis { get; set; }   
    }
}
