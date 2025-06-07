using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Quiz_Plateform.LoginForm;

namespace Quiz_Plateform.UpdateProfile
{

    public partial class updateProfile: Form
    {
        String oldEmail;
        public updateProfile(String stuEmail)
        {
            InitializeComponent();
            oldEmail = stuEmail;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text;
            string newEmail = txtEmail.Text;
            string newPassword = txtPassword.Text;

            string connectionString = "User Id=system;Password=db123;Data Source=localhost:1521/XE;";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
            UPDATE STUDENTS
            SET name = :newName,
                email = :newEmail,
                password = :newPassword
            WHERE email = :oldEmail";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("newName", newName));
                        cmd.Parameters.Add(new OracleParameter("newEmail", newEmail));
                        cmd.Parameters.Add(new OracleParameter("newPassword", newPassword));
                        cmd.Parameters.Add(new OracleParameter("oldEmail", oldEmail));

                        int rowsUpdated = cmd.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Account updated successfully! please login with new Email");
                            loginForm loginForm = new loginForm();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No account found with the given email.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
