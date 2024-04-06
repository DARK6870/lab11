using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.UsersCRUD
{
    public interface IUserRepository
    {
        Task<List<UserViewModel>> GetAllUsers();
        Task<bool> AddNewUser(User user);
    }
}
