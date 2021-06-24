using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Quanlycuahangtienloi
{
    
    public partial class FmMain : Form
    {
        string chucvu = "", ho = "", tenlot = "", tennv = "", manv="";
        public FmMain()
        {
            InitializeComponent();
            siticoneShadowForm1.SetShadowForm(this);
        }
        public FmMain(string chucvu, string ho, string tenlot, string tennv,string manv)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            this.ho = ho;
            this.tenlot = tenlot;
            this.tennv = tennv;
            this.manv = manv;
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if(this.pn_giua.Controls.Count>0)
            {
                this.pn_giua.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pn_giua.Controls.Add(fh);
            this.pn_giua.Tag = fh;
            fh.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (LeftPanel.Width == 260)
            {
                LeftPanel.Width = 85;
            }
            else
                LeftPanel.Width = 260;

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_phongto_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_thunhomanhinh.Visible = true;
            btn_phongto.Visible = false;
        }

        private void btn_thunhomanhinh_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_phongto.Visible = true;
            btn_thunhomanhinh.Visible = false;
        }

        private void btn_thunho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_sanpham_Click(object sender, EventArgs e)
        {
           
        }
        private void pn_giua_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Fmgiaodien());
            lbl_chucvu.Text ="Chức vụ: "+chucvu;
            lbl_tennv.Text ="Tên: " + ho +" "+tenlot +" "+ tennv;
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tennv_Click(object sender, EventArgs e)
        {

        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Fmgiaodien());
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new profile());
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Doimaukhau());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show(" Bạn có muốn đăng xuất hay không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(tb==DialogResult.Yes)
            {
                this.Hide();
                Đăng_nhập dn = new Đăng_nhập();
                dn.Show();

            }
        }
    }

       
}
