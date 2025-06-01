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
using static System.Formats.Asn1.AsnWriter;

namespace Quiz_Plateform.ResultForm
{
    public partial class Result: Form
    {
        String stuEmail;
        String studentName;
        String studentId;
        String quizId;
        String quizTitle;
        int score;
        DateTime attemptDate;
        public Result(string stuEmail, string quizTitle, int score, DateTime attemptDate)
        {
            InitializeComponent();
            this.quizTitle = quizTitle;
            this.score = score;
            this.attemptDate = attemptDate;
            this.stuEmail = stuEmail;
          
        }

        private void Result_Load(object sender, EventArgs e)
        {
            string connStr = "User Id=system;Password=db123;Data Source=localhost:1521/XE;";
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                //Edr ma na student name retrive kya ha email ki madad sa
                string query = "SELECT name FROM STUDENTS WHERE email = :semail";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("semail", stuEmail)); // ya email bhi use kar sakte ho
                    studentName = cmd.ExecuteScalar()?.ToString();
                    lblName.Text = studentName;
                }
                //edr ma na student id and quiz id retrive kya ha email and quiz title ki madad sa store krna ka lia
                String query2 = @"
        SELECT s.student_id, q.quiz_id
        FROM STUDENTS s, QUIZZES q
        WHERE s.email = :email AND q.quiz_title = :category";

                using (OracleCommand cmd = new OracleCommand(query2, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("email", stuEmail));
                    cmd.Parameters.Add(new OracleParameter("category", quizTitle));

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            studentId = reader["student_id"].ToString();
                            quizId = reader["quiz_id"].ToString();
                            lblQuizTitle.Text = quizTitle;
                            lblScore.Text = score.ToString() + "/10";
                            lblDate.Text = attemptDate.ToShortDateString();
                        }
                    }
                }

                //edr result table ma insert krna ka lia query likhi ha
                string insertQuery = "INSERT INTO RESULTS (student_id, quiz_id, score, attempt_date) VALUES (:sid, :qid, :score, SYSDATE)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("sid", studentId));  // login se pass kiya hua
                    cmd.Parameters.Add(new OracleParameter("qid", quizId));     // quiz_id based on selected quiz
                    cmd.Parameters.Add(new OracleParameter("score", score));
                    cmd.ExecuteNonQuery();
                }
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stuDashboard dashboard = new stuDashboard(stuEmail);
            this.Hide();
            dashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
