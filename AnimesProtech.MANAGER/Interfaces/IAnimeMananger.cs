using AnimesProtech.DTO.AnimesDTO;

namespace AnimesProtech.MANAGER.Interfaces
{
    public interface IAnimeManager
    {
        //ResponseAnimeDTO GetAnimes()
        ResponseAnimeDTO Register(string name, string description, long idDirector);
        ResponseAnimeDTO Update(long id, string name, string description, long idDirector);
    }
}
