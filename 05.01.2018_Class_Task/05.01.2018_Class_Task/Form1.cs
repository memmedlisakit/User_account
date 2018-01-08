using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05._01._2018_Class_Task
{
    public partial class Form1 : Form
    {
        private UserDBEntities db = new UserDBEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (User item in db.Users.ToList())
            {
                if (item.Email == this.txtEmail.Text && item.Password == this.txtPassword.Text)
                {
                    // passing profile
                    Profile pr = new Profile();
                    pr.lblName.Text = item.Name;
                    pr.lblSurname.Text = item.Surname;
                    pr.lblEmail.Text = item.Email;
                    pr.lblPassword.Text = item.Password;                    
                    pr.lblPhone.Text = item.Phone;
                    string path = @"C:\Users\Sakit\source\repos\05.01.2018_Class_Task\05.01.2018_Class_Task\Uploads\"+item.Photo;
                    pr.pctrProfile.Image = Image.FromFile(path);
                    pr.ShowDialog();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.ShowDialog();
        }
    }
}
