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
using System.Collections.Generic;
namespace Quiz_Plateform.Quizform
{
    public partial class quizForm : Form
    {
        private string quizCategory;
        private int currentQuestionIndex = 0;

        private class Question
        {
            public string Text;
            public string[] Options;
            public string CorrectAnswer;
        }

        private List<Question> questions = new List<Question>();

        public quizForm(String category)
        {
            InitializeComponent();
            quizCategory = category;
        }

        //This method loads question
        private void LoadQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];
                lblQuestion.Text = q.Text;
                rbtnOption1.Text = q.Options[0];
                rbtnOption2.Text = q.Options[1];
                rbtnOption3.Text = q.Options[2];
                rbtnOption4.Text = q.Options[3];
            }
            else
            {
                MessageBox.Show("Quiz completed!");
                this.Close();
                // Aap result form open kar sakte ho yahan
            }
        }


        private void quizForm_Load(object sender, EventArgs e)
        {
            String connectionString = "User Id=system;Password=db123;Data Source=localhost:1521/XE;";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to the database successfully.");
                    string query = @"
                SELECT q.question_text, q.option_a, q.option_b, q.option_c, q.option_d, q.correct_option
                FROM QUESTIONS q
                JOIN QUIZZES z ON q.quiz_id = z.quiz_id
                WHERE z.quiz_title = :category";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("category", quizCategory));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questions.Add(new Question
                                {
                                    Text = reader.GetString(0),
                                    Options = new string[] {
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4)
                            },
                                    CorrectAnswer = reader.GetString(5)
                                });
                            }
                        }
                    }

                    LoadQuestion();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading quiz: " + ex.Message);
                    MessageBox.Show("Error loading quiz: " + ex.Message);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            LoadQuestion();
        }
    }
}
