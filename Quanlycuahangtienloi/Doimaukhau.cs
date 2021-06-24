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
    public partial class Doimaukhau : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ARL6LSR\MINHTUAN92;Initial Catalog=qlcuahang;Integrated Security=True");
        public Doimaukhau()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_mkcu.UseSystemPasswordChar = false;
                txt_mkmoi.UseSystemPasswordChar = false;
                txt_xacnhanmk.UseSystemPasswordChar = false;
            }
            else
            {
                txt_mkcu.UseSystemPasswordChar = true;
                txt_mkmoi.UseSystemPasswordChar = true;
                txt_xacnhanmk.UseSystemPasswordChar = true;
            }
        }

        private void Doimaukhau_Shown(object sender, EventArgs e)
        {
            txt_taikhoan.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count (*) from nhanvien where taikhoan ='" + txt_taikhoan.Text + "'and matkhau ='" + txt_mkcu.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (txt_taikhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_taikhoan.Focus();
            }
            else if (txt_mkcu.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu củ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mkcu.Focus();
            }
            else if (txt_mkmoi.Text == txt_mkcu.Text)
            {
                MessageBox.Show("Mật khẩu mới trùng với mật khẩu củ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mkmoi.Focus();
            }
            else if (txt_mkmoi.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mkmoi.Focus();
            }
            else if (txt_xacnhanmk.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập xác nhận mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_xacnhanmk.Focus();
            }
            else if(txt_xacnhanmk.Text!=txt_mkmoi.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu khác với mật khẩu mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_xacnhanmk.Focus();
            }
            else if (dt.Rows[0][0].ToString() == "1")
            {
                if (txt_mkmoi.Text == txt_xacnhanmk.Text)
                {
                    SqlCommand cmd1 = new SqlCommand("update nhanvien set matkhau='" + txt_mkmoi.Text + "' where taikhoan ='" + txt_taikhoan.Text + "'and matkhau='" + txt_mkcu.Text + "'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    DialogResult dn = MessageBox.Show(" Đổi mật khẩu thành công. Vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dn == DialogResult.OK)
                    {
                        //this.Hide();
                        // Đăng_nhập dn1 = new Đăng_nhập();
                        //dn1.Show();
                        Application.Restart();
                    }

                }
            }
            else if (dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Đổi mật khẩu không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_taikhoan.Text = "";
                txt_mkmoi.Text = "";
                txt_mkcu.Text = "";
                txt_xacnhanmk.Text = "";
                txt_taikhoan.Focus();
            }
            con.Close();
        }
    }
}
