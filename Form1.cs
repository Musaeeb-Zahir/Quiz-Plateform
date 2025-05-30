using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quiz_Plateform.LoginForm;
using Quiz_Plateform.RegisterForm;

namespace Quiz_Plateform
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginForm loginForm=new loginForm();
            loginForm.Show();
            this.Hide();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registerForm register= new registerForm();
            register.Show();
            this.Hide();
        }
    }
}
