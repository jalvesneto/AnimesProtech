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
        public Director AddDirector(RegisterDirectorDTO anime);
    }
}
