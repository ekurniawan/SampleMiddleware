using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMiddleware.Models;

namespace SampleMiddleware.Services
{
    public class JenisDAL : IJenis
    {
        public Task Delete(Jenis obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Jenis>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Jenis> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Jenis>> GetJenisByName(string nama)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Jenis obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Jenis obj)
        {
            throw new NotImplementedException();
        }
    }
}
