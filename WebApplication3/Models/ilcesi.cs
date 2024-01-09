using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class ilcesi
    {
        [Key]
        public  int ilce_Id { get; set; }
        [Required(ErrorMessage ="İlçe Adı Boş Geçilemez")]
        [DisplayName("İlçenin Adı")]
        public string ilce_Adi { get; set; } = string.Empty;
        [ForeignKey("ili")]
        [DisplayName("İlin Adı")]
        [Required(ErrorMessage ="İlin Adı")]
        public int? il_Id { get; set; }
        public virtual ili? ili { get; set; }
    }
}
