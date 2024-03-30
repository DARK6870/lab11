using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.StatusesCRUD
{
    public interface IStatusRepository
    {
        Task<List<StatusViewModel>> GetAllStatuses();
    }
}
