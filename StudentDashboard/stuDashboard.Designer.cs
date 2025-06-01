namespace Quiz_Plateform.StudentDashboard
{
    partial class stuDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartQuiz = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPreResult = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(346, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(66, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome Ali";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(504, 22);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(71, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "LogOut";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartQuiz);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Location = new System.Drawing.Point(211, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 217);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Quizes";
            // 
            // btnStartQuiz
            // 
            this.btnStartQuiz.Location = new System.Drawing.Point(99, 118);
            this.btnStartQuiz.Name = "btnStartQuiz";
            this.btnStartQuiz.Size = new System.Drawing.Size(75, 23);
            this.btnStartQuiz.TabIndex = 1;
            this.btnStartQuiz.Text = "Start Quiz";
            this.btnStartQuiz.UseVisualStyleBackColor = true;
            this.btnStartQuiz.Click += new System.EventHandler(this.btnStartQuiz_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(99, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.Text = "choice Quiz";
            // 
            // btnPreResult
            // 
            this.btnPreResult.Location = new System.Drawing.Point(101, 295);
            this.btnPreResult.Name = "btnPreResult";
            this.btnPreResult.Size = new System.Drawing.Size(94, 23);
            this.btnPreResult.TabIndex = 4;
            this.btnPreResult.Text = "Previous Result";
            this.btnPreResult.UseVisualStyleBackColor = true;
            this.btnPreResult.Click += new System.EventHandler(this.btnPreResult_Click);
            // 
            // stuDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPreResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Name = "stuDashboard";
            this.Text = "stuDashboard";
            this.Load += new System.EventHandler(this.stuDashboard_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Button btnPreResult;
    }
}