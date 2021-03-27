using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
  
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            TextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() 
            {
                Filter= "txt files (*.txt)|*.txt|All files (*.*)|*.*", 
                ValidateNames=true,
                Multiselect = false 
            })

            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    FileInfo file = new FileInfo(path);
                    StreamReader reader = file.OpenText();
                    string str = " ";
                    while ((str = reader.ReadLine()) != null)
                    {
                        TextBox.Text += str;
                    }
                    reader.Close();                  
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Content = TextBox.Text;
            using (SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                ValidateNames = true
            })

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveDialog.FileName;
                File.WriteAllText(path, Content);
            }

        }       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
