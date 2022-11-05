using AnimesProtech.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimesProtech.DAL.Models
{
    public class Anime
    {
        [Required]
        public long AnimeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Diretor")]
        public long DiretorId { get; set; }
        public Director Diretor { get; set; }

        public bool isDeleted { get; set; }

    }
}
