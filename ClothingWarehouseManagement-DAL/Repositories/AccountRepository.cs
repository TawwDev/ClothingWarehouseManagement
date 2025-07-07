using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class AccountRepository
    {
        private ClothingWarehouseManagementContext _context = new ClothingWarehouseManagementContext();

        public Account? GetAccount(string userName, string email, string passWord)
        {
            return _context.Accounts.FirstOrDefault(x => (x.UserName.ToLower() == userName.ToLower() || x.Email.ToLower() == email.ToLower()) && x.Password == passWord);
        }

    }
}
