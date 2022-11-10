using AnimesProtech.DAL.Models;
using AnimesProtech.DTO.DirectorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.REPOSITORY.Interfaces
{
    public interface IDirectorRepository
    {
        Director GetDirectorById(long id);

        List<Director> GetDirectors(int page);

        List<Director> GetDirectorByName(string name, int page);

        Director AddDirector(RegisterDirectorDTO anime);

        Director EditDirector(Director director);

        Director SetDeleted(Director director);
    }
}
