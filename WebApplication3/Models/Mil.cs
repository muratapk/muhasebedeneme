using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class Mil
	{
		[Key]
        public int MilId { get; set; }
		public string MilAdi { get; set; } = string.Empty;
		public virtual List<Milce>? Milces { get; set; }	
    }
}
