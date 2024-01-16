using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
	public class Milce
	{
		[Key]
		public int MilceId { get; set; }
		public string MilceName { get; set;}=String.Empty;
		public int MilId {  get; set; }	
		public virtual Mil? Mil { get; set; }

	}
}
