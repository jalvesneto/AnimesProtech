using AnimesProtech.DTO.DirectorDTO;

namespace AnimesProtech.MANAGER.Interfaces
{
    public interface IDirectorManager
    {
        DirectorResponseDTO Register(RegisterDirectorDTO director);
    }
}
