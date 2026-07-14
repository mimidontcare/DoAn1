using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class AccountDAL
    {
        private DataProvider _dataProvider;
        public AccountDAL()
        {
            _dataProvider = new DataProvider();
        }

        public bool CheckLogin(string userName, string passWord)
        {
            string query = $"select * from TAIKHOAN where TenDangNhap = '{userName}' AND MatKhau = '{passWord}'";
            return _dataProvider.ExecuteQuery(query).Rows.Count > 0;
        }
    }
}
