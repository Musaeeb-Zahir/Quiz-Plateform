namespace Quiz_Plateform.Quizform
{
    partial class quizForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbtnOption4 = new System.Windows.Forms.RadioButton();
            this.rbtnOption3 = new System.Windows.Forms.RadioButton();
            this.rbtnOption2 = new System.Windows.Forms.RadioButton();
            this.rbtnOption1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Controls.Add(this.rbtnOption4);
            this.groupBox1.Controls.Add(this.rbtnOption3);
            this.groupBox1.Controls.Add(this.rbtnOption2);
            this.groupBox1.Controls.Add(this.rbtnOption1);
            this.groupBox1.Location = new System.Drawing.Point(196, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(6, 52);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(73, 13);
            this.lblQuestion.TabIndex = 6;
            this.lblQuestion.Text = "SQL full form?";
            // 
            // rbtnOption4
            // 
            this.rbtnOption4.AutoSize = true;
            this.rbtnOption4.Location = new System.Drawing.Point(9, 189);
            this.rbtnOption4.Name = "rbtnOption4";
            this.rbtnOption4.Size = new System.Drawing.Size(85, 17);
            this.rbtnOption4.TabIndex = 5;
            this.rbtnOption4.TabStop = true;
            this.rbtnOption4.Text = "radioButton4";
            this.rbtnOption4.UseVisualStyleBackColor = true;
            // 
            // rbtnOption3
            // 
            this.rbtnOption3.AutoSize = true;
            this.rbtnOption3.Location = new System.Drawing.Point(9, 155);
            this.rbtnOption3.Name = "rbtnOption3";
            this.rbtnOption3.Size = new System.Drawing.Size(85, 17);
            this.rbtnOption3.TabIndex = 4;
            this.rbtnOption3.TabStop = true;
            this.rbtnOption3.Text = "radioButton3";
            this.rbtnOption3.UseVisualStyleBackColor = true;
            // 
            // rbtnOption2
            // 
            this.rbtnOption2.AutoSize = true;
            this.rbtnOption2.Location = new System.Drawing.Point(9, 119);
            this.rbtnOption2.Name = "rbtnOption2";
            this.rbtnOption2.Size = new System.Drawing.Size(85, 17);
            this.rbtnOption2.TabIndex = 3;
            this.rbtnOption2.TabStop = true;
            this.rbtnOption2.Text = "radioButton2";
            this.rbtnOption2.UseVisualStyleBackColor = true;
            // 
            // rbtnOption1
            // 
            this.rbtnOption1.AutoSize = true;
            this.rbtnOption1.Location = new System.Drawing.Point(9, 83);
            this.rbtnOption1.Name = "rbtnOption1";
            this.rbtnOption1.Size = new System.Drawing.Size(85, 17);
            this.rbtnOption1.TabIndex = 2;
            this.rbtnOption1.TabStop = true;
            this.rbtnOption1.Text = "radioButton1";
            this.rbtnOption1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Q1 out of 10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "timer 10min left";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(461, 342);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // quizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "quizForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.quizForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbtnOption4;
        private System.Windows.Forms.RadioButton rbtnOption3;
        private System.Windows.Forms.RadioButton rbtnOption2;
        private System.Windows.Forms.RadioButton rbtnOption1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button2;
    }
}