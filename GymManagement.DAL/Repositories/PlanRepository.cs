using GymManagement.DAL.Context;
using GymManagement.DAL.Models;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.DAL.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        public readonly GymDbContext _context;
        public PlanRepository(GymDbContext Context)
        {
            _context = Context;
        }
        public async Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken tk = default)
        {
            IQueryable<Plan> query = tracking ? _context.Plans : _context.Plans.AsNoTracking();
            return await query.ToListAsync(tk);
        }
        public async Task<Plan> GetByIdAsync(int id, CancellationToken tk = default)
        {
            return await _context.Plans.FindAsync(id, tk);
        }
        public async Task<int> AddAsync(Plan plan, CancellationToken tk = default)
        {
            _context.Plans.Add(plan);
            return await _context.SaveChangesAsync(tk);
        }
        public async Task<int> UpdateAsync(Plan plan, CancellationToken tk = default)
        {
            _context.Plans.Update(plan);
            return await _context.SaveChangesAsync(tk);
        }
        public async Task<int> DeleteAsync(Plan plan, CancellationToken tk = default)
        {
            _context.Plans.Remove(plan);
            return await _context.SaveChangesAsync(tk);
        }
    }
}
