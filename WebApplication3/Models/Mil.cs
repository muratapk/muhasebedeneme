using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class Mil
	{
		[Key]
        public int MilId { get; set; }
		[Display(Name="İlin Adı")]
		[Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
		public string MilAdi { get; set; } = string.Empty;
		public virtual List<Milce>? Milces { get; set; }	
    }
}
