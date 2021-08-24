using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace File_Extensions_Add_or_Change
{
    public partial class Form1 : Form
    {
        
        public List<string> namesOfFiles = new List<string>();

        AddExtension AddExtension = new AddExtension();
        DropBoxPreDefined dropBoxPreDefined = new DropBoxPreDefined();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog1.Filter = "All Files";
            openFileDialog1.Multiselect = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Select Files Button

            DialogResult dr = openFileDialog1.ShowDialog();
            AddExtension.ClearTheScreen();

            if (dr == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    string pathName = Path.GetFullPath(file);
                    AddExtension.ThisIsTheFIlePathOfFiles(pathName);

                    string fileName = Path.GetFileName(file);
                    listView1.Items.Add(fileName);
                    namesOfFiles.Add(fileName);
                }
            }

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                AddExtension.NameOfFIles(namesOfFiles);
                button2.Enabled = false;
            }

            else
            {
                textBox1.Enabled = false;
                textBox1.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = true;
                dropBoxPreDefined.FillComboBox();
                button2.Enabled = false;
            }

            else
            {
                comboBox1.Enabled = false;
                dropBoxPreDefined.ClearComboBox();
            }
            
        }
        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //AddExtension.ExtensionAddition(textBoxFilled);
               // AddExtension.CheckTheString();
                AddExtension.ExtensionAddition(AddExtension.CheckTheString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //start button

            AddExtension.StartTheChange();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Exit button

            this.Close();
        }
    }
}
