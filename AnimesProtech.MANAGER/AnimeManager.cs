using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.REPOSITORY;
using AnimesProtech.REPOSITORY.Interfaces;
using System.IO;

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
                string nameDirector = "";
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);
                if (director != null)
                {
                    nameDirector = director.Name;
                }

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = nameDirector;

                response.Add(responseAnime);
            }

            return response;
        }

        public ResponseAnimeDTO GetAnimeById(long id)
        {
            ResponseAnimeDTO response = new ResponseAnimeDTO();

            try
            {
                var result = _animeRepository.GetAnimeById(id);
                if (result == null) {
                    throw new OperationCanceledException("Não foi possível encontrar um Anime com o Id fornecido!");
                }
                else
                {
                    string nameDirector = "";
                    var director = _directorRepository.GetDirectorById(result.DiretorId);
                    if (director != null)
                    {
                        nameDirector = director.Name;
                    }

                    response.AnimeId = result.AnimeId;
                    response.AnimeName = result.Name;
                    response.Description = result.Description;
                    response.DirectorName = nameDirector;

                    return response;
                }

            }
            catch
            {
                throw;
            }

        }

        public List<ResponseAnimeDTO> GetAnimesByDirector(long idDirector, int page)
        {
            List<ResponseAnimeDTO> response = new List<ResponseAnimeDTO>();

            var director = _directorRepository.GetDirectorById(idDirector);

            if (director == null)
            {
                throw new OperationCanceledException("Não Existe diretor com esse id");
            }

            var result = _animeRepository.GetAnimesByDirector(idDirector, page);

            foreach (var resultItem in result)
            {
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
                string nameDirector = "";
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);
                if (director != null)
                {
                    nameDirector = director.Name;
                }

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = nameDirector;

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
                string nameDirector = "";
                var director = _directorRepository.GetDirectorById(resultItem.DiretorId);
                if (director != null)
                {
                    nameDirector = director.Name;
                }

                ResponseAnimeDTO responseAnime = new ResponseAnimeDTO();
                responseAnime.AnimeId = resultItem.AnimeId;
                responseAnime.AnimeName = resultItem.Name;
                responseAnime.Description = resultItem.Description;
                responseAnime.DirectorName = nameDirector;

                response.Add(responseAnime);
            }

            return response;
        }

        public ResponseAnimeDTO Register(RegisterAnimeDTO requestanime)
        {
            try
            {
                var director = _directorRepository.GetDirectorById(requestanime.IdDirector);
                if (director == null)
                {
                    throw new ArgumentException("Não existe um Diretor com esse id");
                }
                var responseAnime = _animeRepository.AddAnime(requestanime);

                var newAnime = new ResponseAnimeDTO()
                {
                    AnimeId = responseAnime.AnimeId,
                    AnimeName = responseAnime.Name,
                    Description = responseAnime.Description,
                    DirectorName = director.Name,
                };

                return newAnime;
            }
            catch (OperationCanceledException ex)
            {
                throw new ArgumentException("Não existe um Diretor com esse id");
            }
            catch
            {
                throw;
            }

        }

        public UpdateAnimeDTO Update(UpdateAnimeDTO anime)
        {
            try
            {
                var editableAnime = _animeRepository.GetAnimeById(anime.AnimeId);
                if (editableAnime == null)
                {
                    throw new ArgumentException("Não existe um Anime com esse id");
                }
                var diretor = _directorRepository.GetDirectorById(anime.DiretorId);
                if (diretor == null)
                {
                    throw new ArgumentException("Não existe um Diretor com esse id");
                }

                editableAnime.Name = anime.Name;
                editableAnime.Description = anime.Description;
                editableAnime.DiretorId = anime.DiretorId;
            
                _animeRepository.EditAnime(editableAnime);

                return anime;
            }
            catch (OperationCanceledException ex)
            {
                throw new ArgumentException("Não foi possível encontrar um Anime ou Diretor com os id's passados.");
            }
            catch
            {
                throw;
            }
        }

        public string Delete(long id)
        {
            try
            {
                var editableAnime = _animeRepository.GetAnimeById(id);
                if (editableAnime == null)
                {
                    throw new OperationCanceledException("Não foi possível encontrar um Anime com o Id passado.");
                }
                var result = _animeRepository.SetDeleted(editableAnime);
                return ($"Anime de id = {id} excluído com sucesso.");
            }
            catch
            {
                throw;
            }
        }

    }
}
