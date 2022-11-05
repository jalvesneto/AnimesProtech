using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.REPOSITORY.Interfaces;
using AnimesProtech.MANAGER.Interfaces;

namespace AnimesProtech.MANAGER
{
    public class DirectorManager : IDirectorManager
    {
        IDirectorRepository _directorRepository;

        public DirectorManager(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public DirectorResponseDTO Register(RegisterDirectorDTO director)
        {
            var newDirector = _directorRepository.AddDirector(director);
            DirectorResponseDTO response = new DirectorResponseDTO()
            {
                Id = newDirector.Id,
                Name = newDirector.Name,
            };
            return response;
        }
    }
}
