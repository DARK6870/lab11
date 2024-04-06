using lab11.Entityes;
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
        Task<Status> GetStatusById(byte ID);
        Task<bool> AddNewStatus(Status model);
        Task<bool> DeleteStatusById(byte ID);
        Task<bool> UpdateStatus(Status model);
        Task<List<string>> GetAllStatusNames();
        Task<byte> GetStatusIdByStatusName(string name);
    }
}
