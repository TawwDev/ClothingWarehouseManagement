using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DAL.Repositories;

namespace ClothingWarehouseManagement_DLL.Services
{
    public class AccountService
    {
        private AccountRepository _account = new AccountRepository();

        public Account? Authenticate(string userName, string email, string passWord)
        {
            return _account.GetAccount(userName, email, passWord);
        }

    }
}
