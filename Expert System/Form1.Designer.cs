namespace Expert_System
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionsText = new System.Windows.Forms.RichTextBox();
            this.AutorText = new System.Windows.Forms.RichTextBox();
            this.ObjectsText = new System.Windows.Forms.RichTextBox();
            this.QuestionText = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // QuestionsText
            // 
            this.QuestionsText.Location = new System.Drawing.Point(12, 290);
            this.QuestionsText.Name = "QuestionsText";
            this.QuestionsText.Size = new System.Drawing.Size(142, 169);
            this.QuestionsText.TabIndex = 0;
            this.QuestionsText.Text = "";
            // 
            // AutorText
            // 
            this.AutorText.Location = new System.Drawing.Point(12, 12);
            this.AutorText.Name = "AutorText";
            this.AutorText.Size = new System.Drawing.Size(514, 61);
            this.AutorText.TabIndex = 1;
            this.AutorText.Text = "";
            // 
            // ObjectsText
            // 
            this.ObjectsText.Location = new System.Drawing.Point(12, 79);
            this.ObjectsText.Name = "ObjectsText";
            this.ObjectsText.Size = new System.Drawing.Size(262, 205);
            this.ObjectsText.TabIndex = 2;
            this.ObjectsText.Text = "";
            // 
            // QuestionText
            // 
            this.QuestionText.Location = new System.Drawing.Point(280, 79);
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.Size = new System.Drawing.Size(246, 205);
            this.QuestionText.TabIndex = 3;
            this.QuestionText.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(160, 290);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(366, 37);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Введите число от -5 до 5.\n-5 НЕТ; 5 ДА ; 0 НЕЗНАЮ";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(402, 290);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(124, 37);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(160, 430);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(91, 29);
            this.OpenFileButton.TabIndex = 6;
            this.OpenFileButton.Text = "OpenFile";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // GoButton
            // 
            this.GoButton.Enabled = false;
            this.GoButton.Location = new System.Drawing.Point(160, 395);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(91, 29);
            this.GoButton.TabIndex = 7;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(435, 333);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(91, 29);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 471);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.QuestionText);
            this.Controls.Add(this.ObjectsText);
            this.Controls.Add(this.AutorText);
            this.Controls.Add(this.QuestionsText);
            this.Name = "Form1";
            this.Text = "Expert System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox QuestionsText;
        private System.Windows.Forms.RichTextBox AutorText;
        private System.Windows.Forms.RichTextBox ObjectsText;
        private System.Windows.Forms.RichTextBox QuestionText;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}

