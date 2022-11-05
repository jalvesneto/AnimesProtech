using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.REPOSITORY;
using AnimesProtech.REPOSITORY.Interfaces;

namespace AnimesProtech.MANAGER
{
    public class AnimeManager : IAnimeManager
    {
        IAnimeRepository _animeRepository;
        IDirectorRepository _directorRepository;

        public AnimeManager(IAnimeRepository animeRepository, IDirectorRepository directorRepository)
        {
            _animeRepository = animeRepository;
            _directorRepository = directorRepository;
        }

        public List<ResponseAnimeDTO> GetAnimes(int page)
        {
            List<ResponseAnimeDTO> response = new List<ResponseAnimeDTO>();

            var result = _animeRepository.GetAnimes(page);

            foreach (var resultItem in result)
            {
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = director.Name;

                response.Add(responseAnime);
            }

            return response;
        }

        public ResponseAnimeDTO GetAnimeById(long id)
        {
            ResponseAnimeDTO response = new ResponseAnimeDTO();

            var result = _animeRepository.GetAnimeById(id);

            if (result == null) {
                throw new OperationCanceledException("Não foi possível encontrar um Anime com o Id fornecido!");
            }
            else
            {
                var director = _directorRepository.GetDirectorById(result.DiretorId);

                response.AnimeId = result.AnimeId;
                response.AnimeName = result.Name;
                response.Description = result.Description;
                response.DirectorName = director.Name;

                return response;
            }
        }

        public List<ResponseAnimeDTO> GetAnimesByDirector(long idDirector, int page)
        {
            List<ResponseAnimeDTO> response = new List<ResponseAnimeDTO>();

            var result = _animeRepository.GetAnimesByDirector(idDirector, page);

            foreach (var resultItem in result)
            {
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = director.Name;

                response.Add(responseAnime);
            }

            return response;
        }

        public List<ResponseAnimeDTO> GetAnimesByTitle(string title, int page)
        {
            List<ResponseAnimeDTO> response = new List<ResponseAnimeDTO>();

            var result = _animeRepository.GetAnimesByTitle(title, page);

            foreach (var resultItem in result)
            {
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = director.Name;

                response.Add(responseAnime);
            }

            return response;
        }

        public List<ResponseAnimeDTO> GetAnimesByKeyWord(string keyword, int page)
        {
            List<ResponseAnimeDTO> response = new List<ResponseAnimeDTO>();

            var result = _animeRepository.GetAnimesByKeyWord(keyword, page);

            foreach (var resultItem in result)
            {
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = director.Name;

                response.Add(responseAnime);
            }

            return response;
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

        public UpdateAnimeDTO Update(UpdateAnimeDTO anime)
        {
            var editableAnime = _animeRepository.GetAnimeById(anime.AnimeId);

            if (editableAnime == null)
            {
                throw new OperationCanceledException("Não foi possível encontrar um anime com o Id passado.");
            }

            editableAnime.Name = anime.Name;
            editableAnime.Description = anime.Description;
            editableAnime.DiretorId = anime.DiretorId;
            
            _animeRepository.EditAnime(editableAnime);

            return anime;
        }

        public string Delete(long id)
        {
            var editableAnime = _animeRepository.GetAnimeById(id);

            if (editableAnime == null)
            {
                throw new OperationCanceledException("Não foi possível encontrar um anime com o Id passado.");
            }
            else
            {
                var result = _animeRepository.SetDeleted(editableAnime);

                return ($"Anime de id = {id} excluído com sucesso.");
            }
        }
    }
}
