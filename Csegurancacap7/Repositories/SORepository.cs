using Csegurancacap7.Data;
using Csegurancacap7.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Csegurancacap7.Repositories
{
    public class SORepository : ISORepository
    {
        private readonly ApplicationDbContext _context;

        public SORepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SO>> GetAllAsync()
        {
            return await _context.SOs.ToListAsync();
        }

        public async Task<SO?> GetByIdAsync(int id)
        {
            return await _context.SOs.FindAsync(id);
        }

        public async Task AddAsync(SO so)
        {
            await _context.SOs.AddAsync(so);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SO so)
        {
            _context.SOs.Update(so);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var so = await _context.SOs.FindAsync(id);
            if (so != null)
            {
                _context.SOs.Remove(so);
                await _context.SaveChangesAsync();
            }
        }
    }
}
