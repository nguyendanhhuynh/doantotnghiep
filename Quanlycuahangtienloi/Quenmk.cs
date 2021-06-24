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
    public partial class Quenmk : Form
    {
        public Quenmk()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ARL6LSR\MINHTUAN92;Initial Catalog=qlcuahang;Integrated Security=True");
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Đăng_nhập dn = new Đăng_nhập();
            dn.Show();
        }

        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from nhanvien where manv ='" + txt_manv.Text + "'and email ='" + txt_email.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(txt_manv.Text.Length==0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txt_email.Text.Length==0)
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dt.Rows.Count>0)
            {
                this.Hide();
                Sendcode sc = new Sendcode(dt.Rows[0][10].ToString());
                sc.Show();
            }
            else if (dt.Rows.Count==0)
            {
                MessageBox.Show(" Mã nhân viên hoặc email chưa đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_manv.Text = "";
                txt_email.Text = "";
                txt_manv.Focus();
            }
            con.Close();
        }
    }
}
