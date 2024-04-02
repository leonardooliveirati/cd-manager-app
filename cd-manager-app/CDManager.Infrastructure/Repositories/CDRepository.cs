using System.Collections.Generic;
using System.Linq;
using CDManager.Domain.Entities;
using CDManager.Domain.Interfaces;
using CDManager.Infrastructure.Persistence;

namespace CDManager.Infrastructure.Repositories
{
    public class CDRepository : ICDRepository
    {
        private readonly AppDbContext _context;

        public CDRepository(AppDbContext context)
        {
            _context = context;
        }

        public CDMusic Create(CDMusic cd)
        {
            _context.CDs.Add(cd);
            _context.SaveChanges();
            return cd;
        }

        public List<CDMusic> GetCDs(string title, string artist, string genre, string musicName)
        {
            var query = _context.CDs.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(cd => cd.Title.Contains(title));

            if (!string.IsNullOrEmpty(artist))
                query = query.Where(cd => cd.Artist.Contains(artist));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(cd => cd.Genre.Contains(genre));

            if (!string.IsNullOrEmpty(musicName))
                query = query.Where(cd => cd.Musics.Any(m => m.Name.Contains(musicName)));

            return query.ToList();
        }
    }
}
