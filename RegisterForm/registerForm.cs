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
using Oracle.ManagedDataAccess.Client;

namespace Quiz_Plateform.RegisterForm
{
    public partial class registerForm: Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

     

            using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO STUDENTS (name, email, password) VALUES (:name, :email, :password)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("name", name));
                        cmd.Parameters.Add(new OracleParameter("email", email));
                        cmd.Parameters.Add(new OracleParameter("password", password));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!");
                            this.Hide();
                            Form1 form1 = new Form1();
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1) 
                    {
                        MessageBox.Show("Email already registered.");
                    }
                    else
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
