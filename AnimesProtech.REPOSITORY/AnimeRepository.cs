using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.DAL.Models;
using AnimesProtech.DAL.DAO;
using AnimesProtech.REPOSITORY.Interfaces;

namespace AnimesProtech.REPOSITORY
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IDAO<Anime> _animeDAO;

        public AnimeRepository(IDAO<Anime> animeDAO)
        {
            _animeDAO = animeDAO;
        }

        public Anime AddAnime(RegisterAnimeDTO anime)
        {
            Anime newAnime = new Anime();
            newAnime.Name = anime.Name;
            newAnime.Description = anime.Description;
            newAnime.DiretorId = anime.IdDirector;
            _animeDAO.Create(newAnime);

            //ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();

            //responseAnime.AnimeId = newAnime.AnimeId;
            //responseAnime.AnimeName = newAnime.Name;
            //responseAnime.Description = newAnime.Description;

            return newAnime;
        }

    }
}
