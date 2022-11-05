using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.AnimesDTO;

namespace AnimesProtech.REPOSITORY.Interfaces
{
    public interface IAnimeRepository
    {
        public Anime AddAnime(RegisterAnimeDTO anime);
    }
}
