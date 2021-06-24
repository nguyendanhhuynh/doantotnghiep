using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlycuahangtienloi
{
    public partial class Fmgiaodien : Form
    {
        public Fmgiaodien()
        {
            InitializeComponent();
        }

        private void pn_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_thoigian_Click(object sender, EventArgs e)
        {

        }

        private void lb_ngythang_Click(object sender, EventArgs e)
        {

        }

        private void Fmgiaodien_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fRam = PRam.NextValue();
            float fCpu = PCpu.NextValue();
            metroProgressBaCpu.Value = (int)fCpu;
            metroProgressBarRam.Value = (int)fRam;
            lbl_cpu.Text = string.Format("{0:0.00}%",fCpu);
            lbl_ram.Text = string.Format("{0:0.00}%", fRam);
            chart1.Series["CPU"].Points.AddY(fCpu);
            chart1.Series["RAM"].Points.AddY(fRam);
            lb_thoigian.Text = DateTime.Now.ToString("HH:mm:ss");
            lb_ngythang.Text = DateTime.Now.ToString("dddd-dd-MM-yyyy");
        }
    }
}
