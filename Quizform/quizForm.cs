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
using Quiz_Plateform.ResultForm;
using static System.Formats.Asn1.AsnWriter;
namespace Quiz_Plateform.Quizform
{
    public partial class quizForm : Form
    {
        private int totalTimeInSeconds =600;
        private string quizCategory;
        String stuEmail;
        int QuestionCount = 1;
        int score = 0;
        int wrongAns = 0;
        private int currentQuestionIndex = 0;

        private class Question
        {
            public string Text;
            public string[] Options;
            public string CorrectAnswer;
        }

        private List<Question> questions = new List<Question>();

        public quizForm(String category,String stuEmail)
        {
            InitializeComponent();
            quizCategory = category;
            this.stuEmail=stuEmail;
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
                button2.Enabled = false;
                rbtnOption1.Checked = false;
                rbtnOption2.Checked = false;
                rbtnOption3.Checked = false;
                rbtnOption4.Checked = false;
                btnNext.Enabled = false;
            }
            else
            {
                MessageBox.Show("Quiz completed! please submit for result");
                btnNext.Enabled = false;
                button2.Enabled = true;
            }
        }


        private void quizForm_Load(object sender, EventArgs e)
        {
            lblQuestionNo.Text = "Q" + QuestionCount.ToString() + " out of 10" ;
          
            using (OracleConnection conn = new OracleConnection(DatabaseConfig.ConnectionString))
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
                    quizTimer.Start();
                   
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
            QuestionCount++;
            lblQuestionNo.Text = "Q" + QuestionCount.ToString() + " out of 10";
            Question currentQuestion = questions[currentQuestionIndex];
            String selectedOption = "";
            
            if (rbtnOption1.Checked) selectedOption = rbtnOption1.Text;
            else if (rbtnOption2.Checked) selectedOption = rbtnOption2.Text;
            else if (rbtnOption3.Checked) selectedOption = rbtnOption3.Text;
            else if (rbtnOption4.Checked) selectedOption = rbtnOption4.Text;
           
                if (selectedOption == currentQuestion.CorrectAnswer)
            {
                score++; 
            }
            else
            {
                wrongAns++; 
            }
            currentQuestionIndex++;
            LoadQuestion();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result resultForm = new Result(stuEmail, quizCategory,score,DateTime.Now);
            resultForm.Show();
            this.Hide();
        }

        private void quizTimer_Tick(object sender, EventArgs e)
        {
            totalTimeInSeconds--;
            if (totalTimeInSeconds <= 60)
            {
                lblTimer.ForeColor = Color.Red;
            }
            int minutes = totalTimeInSeconds / 60;
            int seconds = totalTimeInSeconds % 60;

            lblTimer.Text = $"{minutes:D2}:{seconds:D2}";

            if (totalTimeInSeconds <= 0)
            {
                quizTimer.Stop();
                MessageBox.Show("Time's up! Please Submit for result.");
                btnNext.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void rbtnOption1_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void rbtnOption2_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void rbtnOption3_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void rbtnOption4_CheckedChanged(object sender, EventArgs e)
        {
             btnNext.Enabled = true;
        }
    }
}
