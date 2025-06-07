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
using Quiz_Plateform;
using Quiz_Plateform.PreResult;
using Quiz_Plateform.Quizform;
using Quiz_Plateform.UpdateProfile;

namespace Quiz_Plateform.StudentDashboard
{
    public partial class stuDashboard : Form
    {
        String stuEmail;
        String selectedCategory;
        String user;

        public stuDashboard(String email)
        {
            InitializeComponent(); stuEmail = email.Trim();
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a quiz category first.");
                return;
            }

             selectedCategory = cmbCategory.SelectedItem.ToString();

            quizForm quizForm = new quizForm(selectedCategory,stuEmail); 
            this.Hide(); 
            quizForm.Show();
        }

        private void stuDashboard_Load(object sender, EventArgs e)
        {
        
            try
            {
                using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
                {   
                    conn.Open();
                    //Find name by user email
                    string query1 = "SELECT name FROM STUDENTS WHERE email = :email";
                    using (OracleCommand cmd = new OracleCommand(query1, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("email", stuEmail));
                        user = cmd.ExecuteScalar()?.ToString();
                        lblWelcome.Text = "Welcome, " + user;
                    }
                    String query = "select quiz_title from QUIZZES";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void btnPreResult_Click(object sender, EventArgs e)
        {
            preResultForm resultForm = new preResultForm(stuEmail);
            resultForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete your account?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM STUDENTS WHERE email = :email";

                    using (OracleCommand cmd = new OracleCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("email", stuEmail)); 
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Account deleted.");
                            Application.Exit();  
                        }
                        else
                        {
                            MessageBox.Show("Delete failed.");
                        }
                    }
                }
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            updateProfile updateProfileForm = new updateProfile(stuEmail);
            updateProfileForm.Show();
            this.Hide(); 
        }
    }
}
