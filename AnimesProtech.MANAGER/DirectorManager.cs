using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.REPOSITORY.Interfaces;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.DAL.Models;
using AnimesProtech.REPOSITORY;

namespace AnimesProtech.MANAGER
{
    public class DirectorManager : IDirectorManager
    {
        IDirectorRepository _directorRepository;

        public DirectorManager(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public DirectorResponseDTO GetDirectorById(long id)
        {
            var result = _directorRepository.GetDirectorById(id);

            DirectorResponseDTO response = new DirectorResponseDTO();

            response.Id = id;
            response.Name = result.Name;

            return response;
        }

        public List<DirectorResponseDTO> GetDirectors(int page)
        {
            var result = _directorRepository.GetDirectors(page);

            List<DirectorResponseDTO> response = new List<DirectorResponseDTO>();

            foreach (var director in result)
            {
                DirectorResponseDTO responseDTO = new DirectorResponseDTO();
                responseDTO.Id = director.Id;
                responseDTO.Name = director.Name;

                response.Add(responseDTO);
            }

            return response;
        }

        public List<DirectorResponseDTO> GetDirectorByName(string name, int page)
        {
            var result = _directorRepository.GetDirectorByName(name, page);

            List<DirectorResponseDTO> response = new List<DirectorResponseDTO>();

            foreach (var director in result)
            {
                DirectorResponseDTO responseDTO = new DirectorResponseDTO();
                responseDTO.Id = director.Id;
                responseDTO.Name = director.Name;

                response.Add(responseDTO);
            }

            return response;
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
        public UpdateDirectorDTO Update(UpdateDirectorDTO director)
        {
            var editableDirector = _directorRepository.GetDirectorById(director.Id);

            if (editableDirector == null)
            {
                throw new OperationCanceledException("Não foi possível encontrar um diretor com o Id passado.");
            }

            editableDirector.Name = director.Name;

            _directorRepository.EditDirector(editableDirector);

            return director;
        }

        public string Delete(long id)
        {
            var editableDirector = _directorRepository.GetDirectorById(id);

            if (editableDirector == null)
            {
                throw new OperationCanceledException("Não foi possível encontrar um Diretor com o Id passado.");
            }
            else
            {
                var result = _directorRepository.SetDeleted(editableDirector);

                return ($"Diretor de id = {id} excluído com sucesso.");
            }
        }
    }
}
