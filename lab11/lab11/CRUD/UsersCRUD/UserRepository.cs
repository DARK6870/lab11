using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.UsersCRUD
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context) 
        { 
            _context = context; 
        }

        public async Task<bool> AddNewUser(User user)
        {
            await _context.Users.AddAsync(user);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            var numberedUsers = users.Select((user, index) => new UserViewModel
            {
                i = index + 1,
                UserID = user.UserID,
                UserName = user.UserName,
                RoleName = user.RoleId.ToString(),
                Email = user.Email,
                FullName = user.FullName,
                Adress = user.Adress,
                PhoneNumber = user.PhoneNumber,

            }).ToList();

            return numberedUsers;
        }
    }
}
