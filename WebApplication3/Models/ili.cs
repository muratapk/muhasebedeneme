using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ili
    {
        [Key]
        public int il_Id { get; set; }
        [Required(ErrorMessage ="İl Adını Boş Bırakmazsınız")]
        [DisplayName("İlin Adı")]
        public string il_Adi { get; set; } = string.Empty;
        public virtual List<ilcesi>? ilcesis { get; set; }   
    }
}
