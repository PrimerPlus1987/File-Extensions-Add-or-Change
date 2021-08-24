using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Extensions_Add_or_Change
{
    class AddExtension
    {
        string extensionName { get; set; }
        string textBoxedFilled { get; set; }
        string FilePathOfSelectedFiles { get; set; }

        List<string> filePathOfAllFiles = new List<string>();
        List<string> selectedFileNames = new List<string>();

        static Form1 form1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();

        
        public void ThisIsTheFIlePathOfFiles(string str)
        {
            FilePathOfSelectedFiles = str;

            filePathOfAllFiles.Add(FilePathOfSelectedFiles);

        }

        public void StartTheChange()
        {
            try
            {
                DiableTheButtons();

                for (int i = 0; i < selectedFileNames.Count; i++)
                {
                    form1.listView4.Items.Add(selectedFileNames[i]);
                   // FileInfo fs = new FileInfo(filePathOfAllFiles[i]);
                    File.Move(filePathOfAllFiles[i], filePathOfAllFiles[i] + extensionName, true);
                    form1.listView3.Items.Add(selectedFileNames[i] + extensionName);
                }
                filePathOfAllFiles.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string CheckTheString()
        {
            textBoxedFilled = form1.textBox1.Text;

            if (textBoxedFilled.IndexOf('.') == 0)
            {
                form1.button2.Enabled = true;
                return textBoxedFilled;
            }

            else
            {
                MessageBox.Show("You must use a '.' before declaring your extension.");
                form1.textBox1.Clear();
            }

            return "";
        }

        public void ExtensionAddition(string str)
        {
            extensionName = str;
            CombineThem();
        }

        public void NameOfFIles(List<string> str)
        {
            selectedFileNames = str;
        }

        public void CombineThem()
        {
            form1.listView2.Items.Clear();
            foreach (string file in selectedFileNames)
            {
                form1.listView2.Items.Add(file + extensionName);
            }
        }

        public void DiableTheButtons()
        {
            form1.radioButton1.Enabled = false;
            form1.radioButton2.Enabled = false;
            form1.textBox1.Enabled = false;
            form1.textBox1.Clear();
            form1.comboBox1.Enabled = false;
            form1.comboBox1.Items.Clear();
        }

        public void ClearTheScreen()
        {
            filePathOfAllFiles.Clear();
            selectedFileNames.Clear();
            form1.listView1.Items.Clear();
            form1.listView2.Items.Clear();
            form1.listView3.Items.Clear();
        }

    }
}
