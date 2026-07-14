using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fDangNhap : Form
    {
        private BLL.AccountBLL accountBLL;
        public fDangNhap()
        {
            InitializeComponent();
            accountBLL = new BLL.AccountBLL();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string passWord = txtPass.Text;

            if (ValidateLogin(userName, passWord))
            {
                if (accountBLL.CheckUser(userName, passWord))
                {
                    fTrangChu frm = new fTrangChu();
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private bool ValidateLogin(string userName, string passWord)
        {
            return true;
        }
    }
}
