using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.REPOSITORY;
using AnimesProtech.REPOSITORY.Interfaces;

namespace AnimesProtech.MANAGER
{
    public class AnimeManager : IAnimeManager
    {
        IAnimeRepository _animeRepository;

        public AnimeManager(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public ResponseAnimeDTO Register(string name, string description, long idDirector)
        {
            RegisterAnimeDTO anime = new RegisterAnimeDTO();
            anime.Name = name;
            anime.Description = description;
            anime.IdDirector = idDirector;
            var responseAnime = _animeRepository.AddAnime(anime);

            var newAnime = new ResponseAnimeDTO()
            {
                AnimeId = responseAnime.AnimeId,
                AnimeName = responseAnime.Name,
                Description = responseAnime.Description,
                DirectorName = "a",
            };

            return newAnime;
        }

        public ResponseAnimeDTO Update(long id, string name, string description, long idDirector)
        {
            ResponseAnimeDTO response = new ResponseAnimeDTO();
            response.AnimeId = id;
            response.AnimeName = name;
            response.Description = description;
            response.DirectorName = "lala";
            return response;
        }
    }
}
