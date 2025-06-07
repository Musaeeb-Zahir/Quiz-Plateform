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
using Quiz_Plateform.StudentDashboard;

namespace Quiz_Plateform.PreResult
{
    public partial class preResultForm: Form
    {
        String studentEmail;
        public preResultForm(String studentEmail)
        {
            InitializeComponent();
            this.studentEmail = studentEmail.Trim();
        }

        private void preResultForm_Load(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
            {
                conn.Open();
                // Step 1: Get student_id from email
                string getIdQuery = "SELECT student_id FROM STUDENTS WHERE email = :email";
            OracleCommand idCmd = new OracleCommand(getIdQuery, conn);
            idCmd.Parameters.Add(new OracleParameter("email", studentEmail));
            int studentId = Convert.ToInt32(idCmd.ExecuteScalar());

            // Step 2: Fetch previous results
            string resultQuery = @"
                SELECT q.quiz_title, r.score, r.attempt_date, q.duration_minutes
                FROM RESULTS r
                JOIN QUIZZES q ON r.quiz_id = q.quiz_id
                WHERE r.student_id = :sid";

            OracleCommand resultCmd = new OracleCommand(resultQuery, conn);
            resultCmd.Parameters.Add(new OracleParameter("sid", studentId));

            OracleDataAdapter adapter = new OracleDataAdapter(resultCmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

            //UI better kya ha
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            stuDashboard dashboard = new stuDashboard(studentEmail);
            dashboard.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

