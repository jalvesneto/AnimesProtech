using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.DTO.AnimesDTO
{
    public class UpdateAnimeDTO
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
        public long DiretorId { get; set; }
    }
}
