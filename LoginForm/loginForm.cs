using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_Plateform;
using System.Windows.Forms;
using Quiz_Plateform.StudentDashboard;
using Oracle.ManagedDataAccess.Client;
using Quiz_Plateform.RegisterForm;
namespace Quiz_Plateform.LoginForm
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm();
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text.Trim();
            String password = txtPassword.Text.Trim();
            if (email == " " || password == " ")
            {
                MessageBox.Show("All field are requied!");
            }
            else
            {
               
                try
                {
                    using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
                    {
                        conn.Open();
                        String query = "select count(*) from STUDENTS  where email=:email and password=:password";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("email", email));
                            cmd.Parameters.Add(new OracleParameter("password", password));
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            Console.WriteLine("count: " + count);
                            if (count > 0)
                            {
                                MessageBox.Show("Login successful!");
                                // Open dashboard form here
                                stuDashboard dashboard = new stuDashboard(email);
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.");
                            }
                        }




                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
