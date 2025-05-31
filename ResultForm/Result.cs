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
            lblName.Text = "Name: " + studentName;
            lblQuizTitle.Text = "Quiz: " + quizTitle;
            lblScore.Text = "Score: " + score.ToString();
            lblDate.Text = "Attempted On: " + attemptDate.ToShortDateString();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            string connStr = "User Id=system;Password=db123;Data Source=localhost:1521/XE;";
            using (OracleConnection conn = new OracleConnection(connStr))
            {
                conn.Open();
                string query = "SELECT name FROM STUDENTS WHERE email = :semail";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("semail", stuEmail)); // ya email bhi use kar sakte ho
                    studentName = cmd.ExecuteScalar()?.ToString();
                }

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
                        }
                    }
                }


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
    }
}
