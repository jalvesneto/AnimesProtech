using AnimesProtech.DTO.DirectorDTO;

namespace AnimesProtech.MANAGER.Interfaces
{
    public interface IDirectorManager
    {
        DirectorResponseDTO GetDirectorById(long id);

        List<DirectorResponseDTO> GetDirectors(int page);

        List<DirectorResponseDTO> GetDirectorByName(string name, int page);

        DirectorResponseDTO Register(RegisterDirectorDTO director);

        UpdateDirectorDTO Update(UpdateDirectorDTO director);

        string Delete(long id);
    }
}
