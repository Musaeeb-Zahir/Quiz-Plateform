﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Quiz_Plateform.Quizform;

namespace Quiz_Plateform.StudentDashboard
{
    public partial class stuDashboard : Form
    {
        String stuEmail;
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

            string selectedCategory = cmbCategory.SelectedItem.ToString();

            quizForm quizForm = new quizForm(selectedCategory,stuEmail); 
            this.Hide(); 
            quizForm.Show();
        }

        private void stuDashboard_Load(object sender, EventArgs e)
        {
            String connectionString = "User Id=system;Password=db123;Data Source=localhost:1521/XE;";
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
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
    }
}
