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
            string query = "select * from TAIKHOAN where TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", userName },
                { "@MatKhau", passWord }
            };
            return _dataProvider.ExecuteQuery(query, parameters).Rows.Count > 0;
        }
    }
}
