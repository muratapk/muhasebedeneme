using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ilcesi
    {
        [Key]
        public  int ilce_Id { get; set; }
        public string ilce_Adi { get; set; } = string.Empty;
        public int il_Id { get; set; }
        public virtual ili ili { get; set; }
    }
}
