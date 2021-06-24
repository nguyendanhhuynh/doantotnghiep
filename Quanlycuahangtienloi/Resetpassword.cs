using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quanlycuahangtienloi
{
    public partial class Resetpassword : Form
    {
        string email = Sendcode.to;
        public Resetpassword()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ARL6LSR\MINHTUAN92;Initial Catalog=qlcuahang;Integrated Security=True");
        private void btn_thaydoi_Click(object sender, EventArgs e)
        {
           if(txt_mkmoi.Text==txt_xacminhmk.Text)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update nhanvien set matkhau='" +txt_mkmoi.Text + "' where email ='" +email+ "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                DialogResult dn = MessageBox.Show(" Đổi mật khẩu thành công. Vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dn == DialogResult.OK)
                {
                    //this.Hide();
                    //Đăng_nhập dn1 = new Đăng_nhập();
                    // dn1.Show();
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu ko trùng với mật khẩu mới", "Thông báo");
                }
            }
        }
    }
}
