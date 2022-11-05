using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.DAL.Models;
using AnimesProtech.DAL.DAO;
using AnimesProtech.REPOSITORY.Interfaces;

namespace AnimesProtech.REPOSITORY
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IDAO<Anime> _animeDAO;
        private readonly IDAO<Director> _directorDAO;

        public AnimeRepository(IDAO<Anime> animeDAO, IDAO<Director> directorDAO)
        {
            _animeDAO = animeDAO;
            _directorDAO = directorDAO;
        }

        public List<Anime> GetAnimes(int page)
        {
            List<Anime> animes = new List<Anime>();
            animes = _animeDAO.Get().Where( i => i.isDeleted == false).Skip((page-1) * 10).Take(10).ToList();
            return animes;
        }

        public List<Anime> GetAnimesByDirector(long idDirector, int page)
        {
            List<Anime> animes = new List<Anime>();
            animes = _animeDAO.Get().Where(i => i.DiretorId == idDirector).Where(i => i.isDeleted == false).Skip((page - 1) * 10).Take(10).ToList();
            return animes;
        }


        public List<Anime> GetAnimesByTitle(string title, int page)
        {
            List<Anime> animes = new List<Anime>();
            animes = _animeDAO.Get().Where(i => i.Name.ToLower().Contains(title.ToLower())).Where(i => i.isDeleted == false).Skip((page - 1) * 10).Take(10).ToList();
            return animes;
        }

        public List<Anime> GetAnimesByKeyWord(string keyword, int page)
        {
            List<Anime> animes = new List<Anime>();
            animes = _animeDAO.Get().Where(i => i.Description.ToLower().Contains(keyword.ToLower())).Where(i => i.isDeleted == false).Skip((page - 1) * 10).Take(10).ToList();
            return animes;
        }

        public Anime GetAnimeById(long id)
        {
            try
            {
                return _animeDAO.GetOne(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Anime AddAnime(RegisterAnimeDTO anime)
        {
            Anime newAnime = new Anime();
            newAnime.Name = anime.Name;
            newAnime.Description = anime.Description;
            newAnime.DiretorId = anime.IdDirector;
            newAnime.isDeleted = false;
            _animeDAO.Create(newAnime);

            return newAnime;
        }

        public Anime EditAnime(Anime anime)
        {
            _animeDAO.Update(anime);
            return anime;
        }

        public Anime SetDeleted(Anime anime)
        {
            anime.isDeleted = true;
            _animeDAO.Update(anime);
            return anime;
        }
    }
}
