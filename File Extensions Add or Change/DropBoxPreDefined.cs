using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Extensions_Add_or_Change
{
    class DropBoxPreDefined
    {
        string[] preSetList = {".jpeg", ".jpg", ".mp3", ".bat", ".html", ".docx", ".txt", ".pdf", ".png" };

        static Form1 form1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
        List<string> FixedFileNames = new List<string>();

        AddExtension AddExtension { get; set; }

        public void FillComboBox()
        {
            foreach (string str in preSetList)
            {
                form1.comboBox1.Items.Add(str);
            }
        }

        public void CurrentInstanceOfAddExtension(AddExtension addExtension)
        {
            AddExtension = addExtension;
        }
        public void SelectedDropBoxExtension(string str)
        {
            AddExtension.CheckFileNameExtension(); //First because using current instance of AddExtension so the current list of 
                                                   // FileNames in the class AddExtension is current and is needed for
                                                   //the second method call ExtensionAddition
            AddExtension.ExtensionAddition(str);
            form1.button2.Enabled = true;
  
        }

        public void ClearComboBox()
        {
            form1.comboBox1.Items.Clear();
        }
    }
}
