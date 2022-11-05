using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.DTO.DirectorDTO
{
    public class UpdateDirectorDTO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
