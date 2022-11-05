using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.AnimesDTO;

namespace AnimesProtech.REPOSITORY.Interfaces
{
    public interface IAnimeRepository
    {
        List<Anime> GetAnimes(int page);

        List<Anime> GetAnimesByDirector(long idDirector, int page);

        List<Anime> GetAnimesByTitle(string title, int page);

        List<Anime> GetAnimesByKeyWord(string keyword, int page);

        Anime GetAnimeById(long id);

        Anime AddAnime(RegisterAnimeDTO anime);

        Anime EditAnime(Anime anime);

        Anime SetDeleted(Anime anime);
    }
}
