using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;

namespace ClothingWarehouseManagement_DLL.Services
{
    public static class Session
    {
        public static Account CurrentUser { get; private set; }

        public static void SetCurrentUser(Account user)
        {
            CurrentUser = user;
        }

        public static void ClearCurrentUser()
        {
            CurrentUser = null;
        }
    }
}
