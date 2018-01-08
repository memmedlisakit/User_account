using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05._01._2018_Class_Task
{
    public partial class Register : Form
    {
        private UserDBEntities db = new UserDBEntities();
        OpenFileDialog file = new OpenFileDialog();
        public Register()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            file.ShowDialog();
            this.pctPhoto.Image = Image.FromFile(file.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string image = DateTime.Now.ToString("yyyyMMddHHssmm") + file.SafeFileName;


            //add datbase a user
            User usr = new User();
            usr.Name = txtName.Text;
            usr.Surname = txtSurname.Text;
            usr.Email = txtEmail.Text;
            usr.Password = txtPassword.Text;
            usr.Phone = txtPhone.Text;
            usr.Photo = image;
            db.Users.Add(usr);
            db.SaveChanges();


            // file upload
            WebClient webclient = new WebClient();
            string path = @"C:\Users\Sakit\source\repos\05.01.2018_Class_Task\05.01.2018_Class_Task\Uploads\" + image;
            webclient.DownloadFile(file.FileName, path);
        }
    }
}
