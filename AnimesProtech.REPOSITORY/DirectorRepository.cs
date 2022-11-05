using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.REPOSITORY.Interfaces;
using AnimesProtech.DAL.DAO;

namespace AnimesProtech.REPOSITORY
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IDAO<Director> _directorDAO;

        public DirectorRepository(IDAO<Director> directorDAO)
        {
            _directorDAO = directorDAO;
        }

        public Director AddDirector(RegisterDirectorDTO director)
        {
            Director newDirector = new Director();
            newDirector.Name = director.Name;

            _directorDAO.Create(newDirector);

            return newDirector;
        }
    }
}
