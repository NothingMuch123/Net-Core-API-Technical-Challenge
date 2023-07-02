using Microsoft.EntityFrameworkCore;
using Technical_Challenge.Databases;
using Technical_Challenge.Models;
using Technical_Challenge.Models.API;

namespace Technical_Challenge.DAL
{
    public interface IUniversityDAL
    {
        public Task<List<University>> GetList(GetUniversityRequest req);
        public Task<University?> Get(int id);
        public Task<University> Create(CreateUniversityRequest req);
        public Task<University?> Update(UpdateUniversityRequest req);
        public Task<University?> Update(University u);
        public Task<University?> Delete(int id);
    }

    public class UniversityDAL : IUniversityDAL
    {
        private readonly UniversityContext _context;
        public UniversityDAL(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<University>> GetList(GetUniversityRequest req)
        {
            var query = _context.Universities.Where(u => u.DeletedAt == null);

            // Filter
            if (req.Name != null)
                query = query.Where(u => u.Name.Contains(req.Name));
            if (req.Country != null)
                query = query.Where(u => u.Country.Contains(req.Country));
            if (req.IsActive.HasValue)
                query = query.Where(u => u.IsActive ==  req.IsActive.Value);

            return await query.OrderByDescending(u => u.IsBookmark).ThenBy(u => u.Id).ToListAsync();
        }

        public async Task<University?> Get(int id)
        {
            return await _context.Universities.FindAsync(id); 
        }

        public async Task<University> Create(CreateUniversityRequest req)
        {
            var u = new University(req);
            await _context.Universities.AddAsync(u);
            await _context.SaveChangesAsync();
            return u;
        }

        public async Task<University?> Update(UpdateUniversityRequest req)
        {
            // Fetch
            var u = await Get(req.Id);
            if (u == null)
                return null;

            // Update
            u.Name = req.Name;
            u.Country = req.Country;
            u.Webpages = req.Webpages;
            u.IsActive = req.IsActive.GetValueOrDefault(u.IsActive);

            await Update(u);
            return u;
        }

        public async Task<University?> Update(University u)
        {
            u.LastModified = DateTime.UtcNow;
            _context.Universities.Update(u);
            await _context.SaveChangesAsync();
            return u;
        }

        public async Task<University?> Delete(int id)
        {
            // Fetch
            var u = await Get(id);
            if (u == null)
                return null;

            u.DeletedAt = DateTime.UtcNow;
            await Update(u);
            return u;
        }
    }
}
