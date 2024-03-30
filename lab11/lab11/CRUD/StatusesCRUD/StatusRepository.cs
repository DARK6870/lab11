using lab11.DataBase;
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
    }
}
