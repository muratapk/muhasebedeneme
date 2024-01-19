using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Admin
    {
        [Key]
        public  int AdminId { get; set; }
        public string AdminName { get; set; } = string.Empty;
        public string AdminEmail { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public string AdminUserName { get; set; } = string.Empty;
        public int? OkulId { get; set; }
        public virtual Okul? Okul { get; set; }

    }
}
