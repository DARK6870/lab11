using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.StatusesCRUD
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDBContext _context;
        public StatusRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewStatus(Status model)
        {
            await _context.Statuses.AddAsync(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteStatusById(byte ID)
        {
            Status model = await GetStatusById(ID);
            _context.Statuses.Remove(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<StatusViewModel>> GetAllStatuses()
        {
            var Statuses = await _context.Statuses.ToListAsync();

            var NumberedStatuses = Statuses.Select((status, index) => new StatusViewModel
            {
                i = index + 1,
                StatusId = status.StatusId,
                StatusName = status.StatusName
            }).ToList();

            return NumberedStatuses;
        }

        public async Task<List<string>> GetAllStatusNames()
        {
            var items = await _context.Statuses.ToListAsync();
            List<string> res = items.Select(x => x.StatusName).ToList();
            return res;
        }

        public async Task<Status> GetStatusById(byte ID)
        {
            Status res = await _context.Statuses.FindAsync(ID);
            return res;
        }

        public async Task<byte> GetStatusIdByStatusName(string name)
        {
            Status item = await _context.Statuses.FirstOrDefaultAsync(p => p.StatusName == name);
            byte res = item.StatusId;
            return res;
        }

        public async Task<bool> UpdateStatus(Status model)
        {
            _context.Statuses.Update(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
