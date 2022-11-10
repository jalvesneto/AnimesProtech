using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.DTO.DirectorDTO
{
    public class RegisterDirectorDTO
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}

