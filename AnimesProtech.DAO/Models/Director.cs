using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.DAL.Models
{
    public class Director
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
