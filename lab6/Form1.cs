using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace lab6
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var path = dialog.FileName;
            var fileContent = File.ReadAllText(path);
            label1.Visible = true;
            button1.Enabled = true;

            foreach (var item in fileContent.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNumberTextBox(Convert.ToInt32(item)));

            }
        }

        private TextBox GenerateNumberTextBox(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                Width = 25,
                ReadOnly = true
                
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                var randomNumber = r.Next(100);
                textBox1.Text = randomNumber.ToString();
                flowLayoutPanel2.Controls.Add(GenerateNumberTextBox(randomNumber));
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }
    }
}
