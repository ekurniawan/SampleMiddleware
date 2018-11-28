using SampleMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Services
{
    public interface IJenis : ICrud<Jenis>
    {
        Task<IEnumerable<Jenis>> GetJenisByName(string nama);
    }
}
