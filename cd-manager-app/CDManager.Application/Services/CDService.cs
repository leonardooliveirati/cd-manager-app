using System.Collections.Generic;
using CDManager.Domain.Entities;
using CDManager.Domain.Interfaces;

namespace CDManager.Application.Services
{
    public class CDService : ICDService
    {
        private readonly ICDRepository _cdRepository;

        public CDService(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        public CDMusic CreateCD(CDMusic cd)
        {
            return _cdRepository.Create(cd);
        }

        public List<CDMusic> GetCDs(string title, string artist, string genre, string musicName)
        {
            return _cdRepository.GetCDs(title, artist, genre, musicName);
        }
    }
}
