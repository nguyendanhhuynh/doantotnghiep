 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Quanlycuahangtienloi
{
    public partial class Sendcode : Form
    {
        string ramdomcode;
        public static string to;
        string email = "";
        public Sendcode()
        {
            InitializeComponent();
        }
        public Sendcode(string email)
        { 
            InitializeComponent();
            this.email = email;
        }

        private void Sendcode_Load(object sender, EventArgs e)
        {
            txt_email.Text = email;
        }

        private void Sendcode_Shown(object sender, EventArgs e)
        {
            txt_macode.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_guicode_Click(object sender, EventArgs e)
        {
            string from, pass, messagebody;
            Random ran = new Random();
            ramdomcode = (ran.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txt_email.Text).ToString();
            from = "tdmart921999@gmail.com";
            pass = "Minhtuanmh8819";
            messagebody = "Your Reset Code Is " + ramdomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = " Password reseting code ";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show(" Gửi code thành công, vui lòng kiểm tra mail !");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            if(ramdomcode==(txt_macode.Text).ToString())
            {
                to = txt_email.Text;
                this.Hide();
                Resetpassword rs = new Resetpassword();
                rs.Show();
            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng");
            }
        }
    }
}
