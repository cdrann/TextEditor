namespace TextEditor
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
            this.checkboxCharAmount = new System.Windows.Forms.CheckBox();
            this.checkboxDeletePuncMarks = new System.Windows.Forms.CheckBox();
            this.textBoxCharAmount = new System.Windows.Forms.TextBox();
            this.textBoxDeletePuncMarks = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.FileOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonLoadOut = new System.Windows.Forms.Button();
            this.buttonLoadIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkboxCharAmount
            // 
            this.checkboxCharAmount.AutoSize = true;
            this.checkboxCharAmount.Location = new System.Drawing.Point(2, 12);
            this.checkboxCharAmount.Name = "checkboxCharAmount";
            this.checkboxCharAmount.Size = new System.Drawing.Size(132, 38);
            this.checkboxCharAmount.TabIndex = 0;
            this.checkboxCharAmount.Text = "min количество\r\nсимволов:";
            this.checkboxCharAmount.UseVisualStyleBackColor = true;
            this.checkboxCharAmount.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkboxDeletePuncMarks
            // 
            this.checkboxDeletePuncMarks.AutoSize = true;
            this.checkboxDeletePuncMarks.Location = new System.Drawing.Point(2, 53);
            this.checkboxDeletePuncMarks.Name = "checkboxDeletePuncMarks";
            this.checkboxDeletePuncMarks.Size = new System.Drawing.Size(129, 38);
            this.checkboxDeletePuncMarks.TabIndex = 1;
            this.checkboxDeletePuncMarks.Text = "удалить знаки \r\nпрепинания:";
            this.checkboxDeletePuncMarks.UseVisualStyleBackColor = true;
            this.checkboxDeletePuncMarks.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // textBoxCharAmount
            // 
            this.textBoxCharAmount.Location = new System.Drawing.Point(137, 25);
            this.textBoxCharAmount.Name = "textBoxCharAmount";
            this.textBoxCharAmount.Size = new System.Drawing.Size(100, 22);
            this.textBoxCharAmount.TabIndex = 2;
            // 
            // textBoxDeletePuncMarks
            // 
            this.textBoxDeletePuncMarks.Location = new System.Drawing.Point(137, 68);
            this.textBoxDeletePuncMarks.Name = "textBoxDeletePuncMarks";
            this.textBoxDeletePuncMarks.Size = new System.Drawing.Size(100, 22);
            this.textBoxDeletePuncMarks.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileOut,
            this.State});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 109);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(528, 234);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // FileOut
            // 
            this.FileOut.Text = "Выходной файл";
            this.FileOut.Width = 292;
            // 
            // State
            // 
            this.State.Text = "Состояние";
            this.State.Width = 504;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(12, 380);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(528, 88);
            this.textBox3.TabIndex = 5;
            // 
            // buttonLoadOut
            // 
            this.buttonLoadOut.Location = new System.Drawing.Point(398, 27);
            this.buttonLoadOut.Name = "buttonLoadOut";
            this.buttonLoadOut.Size = new System.Drawing.Size(114, 66);
            this.buttonLoadOut.TabIndex = 6;
            this.buttonLoadOut.Text = "Начать обработку";
            this.buttonLoadOut.UseVisualStyleBackColor = true;
            this.buttonLoadOut.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonLoadIn
            // 
            this.buttonLoadIn.Location = new System.Drawing.Point(268, 25);
            this.buttonLoadIn.Name = "buttonLoadIn";
            this.buttonLoadIn.Size = new System.Drawing.Size(114, 66);
            this.buttonLoadIn.TabIndex = 7;
            this.buttonLoadIn.Text = "Загрузить входной файл";
            this.buttonLoadIn.UseVisualStyleBackColor = true;
            this.buttonLoadIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Info:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoadIn);
            this.Controls.Add(this.buttonLoadOut);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBoxDeletePuncMarks);
            this.Controls.Add(this.textBoxCharAmount);
            this.Controls.Add(this.checkboxDeletePuncMarks);
            this.Controls.Add(this.checkboxCharAmount);
            this.Name = "Form1";
            this.Text = "TextEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxCharAmount;
        private System.Windows.Forms.CheckBox checkboxDeletePuncMarks;
        private System.Windows.Forms.TextBox textBoxCharAmount;
        private System.Windows.Forms.TextBox textBoxDeletePuncMarks;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader FileOut;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonLoadOut;
        private System.Windows.Forms.Button buttonLoadIn;
        private System.Windows.Forms.Label label1;
    }
}

