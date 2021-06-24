using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace Quanlycuahangtienloi
{
    public partial class Đăng_nhập : Form
    {
        public Đăng_nhập()
        {
            InitializeComponent();
        }
        SqlConnection con= new SqlConnection(@"Data Source=DESKTOP-ARL6LSR\MINHTUAN92;Initial Catalog=qlcuahang;Integrated Security=True");

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();  

        }

        private void txt_user_Click(object sender, EventArgs e)
        {
            txt_user.BackColor = Color.White;
            pn_user.BackColor = Color.White;
            txt_password.BackColor =SystemColors.Control;
            pn_pass.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quenmk qkm = new Quenmk();
            qkm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select * from nhanvien where taikhoan ='" + txt_user.Text + "'and matkhau ='" + txt_password.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (txt_user.Text.Length == 0 && txt_password.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng điền mật khẩu và tài khoảng để đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_user.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_password.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    
                }
                else if (dt.Rows.Count>0)
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FmMain main = new FmMain(dt.Rows[0][12].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][0].ToString());
                    this.Hide();
                    main.Show();
            }
                else if(dt.Rows.Count==0)
                {
                    MessageBox.Show("Đăng nhập thất bại, Vui lòng đăng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_user.Text = "";
                    txt_password.Text = "";
                    txt_user.Focus();
                 
                }
            con.Close();
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pn_user_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void pn_pass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Đăng_nhập_Shown(object sender, EventArgs e)
        {
            txt_user.Focus();
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            txt_user.BackColor = SystemColors.Control;
            pn_user.BackColor = SystemColors.Control;
            txt_password.BackColor = Color.White;
            pn_pass.BackColor = Color.White;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
