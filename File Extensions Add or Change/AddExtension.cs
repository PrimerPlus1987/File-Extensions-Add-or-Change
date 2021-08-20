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

         static Form1 form1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();


        List<string> selectedFileNames = new List<string>();

        public void ThisIsTheFIlePathOfFiles(string str)
        {
            FilePathOfSelectedFiles = str;

        }

        public void StartTheChange()
        {
            
            try
            {
                foreach (string file in selectedFileNames)
                {

                    File.Move(FilePathOfSelectedFiles, FilePathOfSelectedFiles + extensionName, true);
                  
                  // File.Copy(file, file + extensionName, true);
                        form1.listView3.Items.Add(file + extensionName);
                        File.Delete(file);
                }
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

        public void ClearTheScreen()
        {
            selectedFileNames.Clear();
            form1.listView2.Items.Clear();
        }

    }
}
