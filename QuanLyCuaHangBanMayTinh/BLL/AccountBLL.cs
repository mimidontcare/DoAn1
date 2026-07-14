using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class AccountBLL
    {
        private DAL.AccountDAL accountDAL;
        public AccountBLL()
        {
            accountDAL = new DAL.AccountDAL();
        }
        public bool CheckUser(string userName, string passWord)
        {
            return accountDAL.CheckLogin(userName, passWord);
        }

    }
}
