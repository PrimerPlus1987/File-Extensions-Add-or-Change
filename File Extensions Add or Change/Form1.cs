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
        DropBoxPreDefined DropBoxPreDefined = new DropBoxPreDefined();

        public Form1()
        {
            InitializeComponent();
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
                    // string pathName = Path.GetFullPath(file);
                    string fileNames = Path.GetFileName(file);
                    string fileFullPath = Path.GetFullPath(file);
                    string pathName = Path.GetDirectoryName(fileFullPath);
                    AddExtension.ThisIsTheFIlePathOfFiles(pathName, fileFullPath, fileNames);
                   // MessageBox.Show("Current directory of " + fileNames + " is " + pathName);
                    
                    listView1.Items.Add(fileNames);
                    namesOfFiles.Add(fileNames);
                }
            }
            openFileDialog1.FileName = "";

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
                AddExtension.NameOfFIles(namesOfFiles);
                DropBoxPreDefined.FillComboBox();
                button2.Enabled = false;
            }

            else
            {
                comboBox1.Enabled = false;
                DropBoxPreDefined.ClearComboBox();
            }
            
        }

       
        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddExtension.ExtensionAddition(AddExtension.CheckTheString());
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string selectedComboBoxExt = comboBox1.SelectedItem.ToString();
                DropBoxPreDefined.CurrentInstanceOfAddExtension(AddExtension);

                DropBoxPreDefined.SelectedDropBoxExtension(selectedComboBoxExt);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //start button

            AddExtension.StartTheChange();
            namesOfFiles.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Exit button

            this.Close();
        }

       
    }
}
