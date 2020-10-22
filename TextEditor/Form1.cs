using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string fileInPath { get; set; }

        private string fileOutName { get; set; }

        private string fileOutPath { get; set; }

        private char[] punctMarks { get; set; }

        private int minWordLen { get; set; }

        public Form1()
        {
            InitializeComponent();
            textBox3.Clear();
            textBox3.AppendText("Добро пожаловать в обработчик текста. " +
                "Выберите опции. Далее выберите файл для обработки");
            listView1.View = View.Details;
            textBoxCharAmount.Enabled = false;
            textBoxDeletePuncMarks.Enabled = false;
            buttonLoadOut.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxCharAmount.Checked)
            {
                textBoxCharAmount.Enabled = true;
                textBox3.Clear();
                textBox3.AppendText("Введите минимальную длину слов в выходном файле. " +
                    "Далее выберите опции или загрузите входной файл.");
            }
            else
            {
                textBoxCharAmount.Text = null;
                textBoxCharAmount.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxDeletePuncMarks.Checked)
            {
                textBoxDeletePuncMarks.Enabled = true;
                textBox3.Clear();
                textBox3.AppendText("Введите знаки препинания, которые необходимо удалить в файле. " +
                    "Далее выберите опции или загрузите входной файл");
            }
            else
            {
                textBoxDeletePuncMarks.Text = null;
                textBoxDeletePuncMarks.Enabled = false;
            }
        }

        private void GetEditedText()
        {
            string fileIn = fileInPath;
            char[] pMarks = punctMarks;
            int minLen = minWordLen;

            StreamWriter file = null;

            string res = "";

            try
            {
                file = new StreamWriter(fileOutPath);

                if (minLen > 0 && pMarks != null && pMarks.Length != 0)
                {
                    foreach (var line in File.ReadLines(fileIn, Encoding.Default))
                    {
                        string[] words = line.Split(' ');
                        foreach (var word in words)
                        {
                            string currWord = word;
                            currWord = word.Trim(pMarks);
                            res += currWord + ' ';
                        }

                        string currLine = res;
                        string recieved = null;
                        recieved += Processing.DeleteWord(currLine, minLen);

                        file.WriteLine(recieved, false, Encoding.Default);
                        res = "";
                    }
                }
                else if (pMarks != null && pMarks.Length != 0)
                {
                    foreach (string line in File.ReadLines(fileIn, Encoding.Default))
                    {
                        string[] words = line.Split(' ');
                        foreach (var word in words)
                        {
                            string currWord = word;
                            currWord = word.Trim(pMarks);
                            res += currWord + ' ';
                        }
                        file.WriteLine(res, fileOutPath, Encoding.Default);
                        res = "";
                    }
                }
                else if (minLen > 0) 
                {
                    foreach (var line in File.ReadLines(fileIn, Encoding.Default))
                    {
                        string currLine = line;
                        string recieved = null;
                        recieved += Processing.DeleteWord(currLine, minLen);

                        file.WriteLine(recieved, false, Encoding.Default);
                        res = "";
                    } 
                }

                file.Close();
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    MessageBox.Show("Ошибка при попытке обработать файл. IOException source: " 
                        + e.Source);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkboxDeletePuncMarks.Checked 
                && !checkboxCharAmount.Checked)
            {
                MessageBox.Show("Необходимо выбрать хотя бы одну опцию.");
            }
            else if (checkboxCharAmount.Checked 
                && string.IsNullOrEmpty(textBoxCharAmount.Text))
            {
                MessageBox.Show("Введите минимальное количество символов в слове.");
            }
            else if (checkboxDeletePuncMarks.Checked 
                && string.IsNullOrEmpty(textBoxDeletePuncMarks.Text)) {
                MessageBox.Show("Введите знаки перпинания.");
            } 
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileInPath = openFileDialog.FileName;

                        if (fileInPath == null)
                        {
                            textBox3.Clear();
                            textBox3.AppendText(fileInPath + " == null");
                        }

                        textBox3.Clear();
                        textBox3.AppendText("Файл для обработки: " + fileInPath + ". Начните обработку.");
                        buttonLoadOut.Enabled = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите выходной файл.");

            Stream myStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream = saveFileDialog.OpenFile();
                    minWordLen = !string.IsNullOrEmpty(textBoxCharAmount.Text) ?
                        Convert.ToInt16(textBoxCharAmount.Text) : -1;
                    punctMarks = textBoxDeletePuncMarks.Text.ToCharArray();

                    fileOutPath = saveFileDialog.FileName;
                    fileOutName = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\'));

                    textBox3.Clear();
                    textBox3.AppendText("Выходной файл: " + fileInPath);

                    if (fileOutName.Equals(fileInPath))
                    {
                        fileOutName = null;
                        textBox3.Clear();
                        textBox3.AppendText("Входной и выходной файл совпадать не могут.");
                    }

                    ListViewItem item = new ListViewItem(fileOutName);
                    item.SubItems.Add("обрабатывается...");
                    listView1.Items.Add(item);
                    listView1.Visible = true;
            
                    ThreadPool.QueueUserWorkItem(new WaitCallback((s) =>
                    {
                        GetEditedText();
                        listView1.BeginInvoke(new InvokeDelegate(InvokeMethod));
                    }));
                    myStream.Close();
                }
                catch (IOException ex)
                {
                    if (ex.Source != null)
                        MessageBox.Show("Ошибка при обработке. IOException source: " + ex.Source);
                }
            }
        }

        public delegate void InvokeDelegate();

        public void InvokeMethod()
        {
            int counter = listView1.FindItemWithText(fileOutName).Index;

            while (listView1.Items[counter].SubItems[1].Text == "завершено")
            {
                counter++;
            }

            listView1.Items[counter].SubItems[1].Text = "завершено";
            textBox3.Clear();
            textBox3.AppendText("Обработка " + fileOutName + " завершена.");
        }
    }
}
