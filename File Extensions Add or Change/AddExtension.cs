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
                DisableTheButtons();

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




        List<string> CheckFileNameExtension()
        {
            List<string> altered = new List<string>();

            for (int i = 0; i < selectedFileNames.Count; i++)
            {
                if(selectedFileNames[i].Contains("."))
                {
                    int index = selectedFileNames[i].IndexOf(".");
                    MessageBox.Show("The index of the '.' is " + index);
                    StringBuilder sb = new StringBuilder(selectedFileNames[i]);

                    sb.Remove(index, selectedFileNames[i].Length);
                   
                    altered.Add(sb.ToString());

                    MessageBox.Show("The altered filename is: " + selectedFileNames[i]);
                    MessageBox.Show("For altered List: " + altered[i]);
                }
                else
                {
                    altered.Add(selectedFileNames[i]);
                }
            }

            selectedFileNames = altered;

            return selectedFileNames;
        }


        public string CheckTheString()
        {
            CheckFileNameExtension();

            textBoxedFilled = '.' + form1.textBox1.Text;

            //need to remove the '.' from text box
            // need to auto enter the '.'
            //if extension is unusual need to ask if that is what whas wanted

            
            if (textBoxedFilled.IndexOf('.') == 0)
            {
                StringBuilder sb = new StringBuilder(textBoxedFilled);
                sb.Remove(0, 1); //This will remove one character starting at index 1 of the string
                textBoxedFilled = sb.ToString();

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

       static public void DisableTheButtons()
        {
            form1.radioButton1.Enabled = false;
            form1.radioButton1.Checked = false;
            form1.radioButton2.Enabled = false;
            form1.radioButton2.Checked = false;
            form1.textBox1.Enabled = false;
            form1.textBox1.Clear();
            form1.comboBox1.Enabled = false;
            form1.comboBox1.Items.Clear();
            form1.button2.Enabled = false;
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
