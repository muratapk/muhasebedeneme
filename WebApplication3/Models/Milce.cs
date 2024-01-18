using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class Milce
	{
		[Key]
		public int MilceId { get; set; }

		[Display(Name ="İlçenin Adı")]
		[Required(ErrorMessage ="Bu Alanı Boş Bırakamazsınız")]
		public string MilceName { get; set;}=String.Empty;

        [Display(Name = "İlin Adı")]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
        public int MilId {  get; set; }

        [Display(Name = "İlin Adı")]
        public virtual Mil? Mil { get; set; }

	}
}
