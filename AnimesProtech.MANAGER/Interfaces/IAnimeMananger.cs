using AnimesProtech.DTO.AnimesDTO;


namespace AnimesProtech.MANAGER.Interfaces
{
    public interface IAnimeManager
    {
        List<ResponseAnimeDTO> GetAnimes(int page);

        ResponseAnimeDTO GetAnimeById(long Id);

        List<ResponseAnimeDTO> GetAnimesByDirector(long idDirector, int page);

        List<ResponseAnimeDTO> GetAnimesByTitle(string title, int page);

        List<ResponseAnimeDTO> GetAnimesByKeyWord(string keyword, int page);

        ResponseAnimeDTO Register(string name, string description, long idDirector);
        UpdateAnimeDTO Update(UpdateAnimeDTO anime);
        string Delete(long id);
    }
}
