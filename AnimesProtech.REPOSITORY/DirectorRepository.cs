using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.REPOSITORY.Interfaces;
using AnimesProtech.DAL.DAO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimesProtech.REPOSITORY
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IDAO<Director> _directorDAO;

        public DirectorRepository(IDAO<Director> directorDAO)
        {
            _directorDAO = directorDAO;
        }

        public List<Director> GetDirectors(int page)
        {
            List<Director> directors = new List<Director>();
            directors = _directorDAO.Get().Where(i => i.isDeleted == false).Skip((page - 1) * 10).Take(10).ToList();
            return directors;
        }

        public List<Director> GetDirectorByName(string nome, int page)
        {
            List<Director> directors = new List<Director>();
            directors = _directorDAO.Get().Where(i => i.Name.ToLower().Contains(nome.ToLower())).Where(i => i.isDeleted == false).Skip((page - 1) * 10).Take(10).ToList();
            return directors;
        }

        public Director GetDirectorById(long id)
        {
            try
            {
                return _directorDAO.Get().Where(i => i.Id == id).Where(i => i.isDeleted == false).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Director AddDirector(RegisterDirectorDTO director)
        {
            Director newDirector = new Director();
            newDirector.Name = director.Name;
            newDirector.isDeleted = false;

            _directorDAO.Create(newDirector);

            return newDirector;
        }

        public Director EditDirector(Director director)
        {
            _directorDAO.Update(director);
            return director;
        }

        public Director SetDeleted(Director director)
        {
            director.isDeleted = true;
            _directorDAO.Update(director);
            return director;
        }
    }
}
