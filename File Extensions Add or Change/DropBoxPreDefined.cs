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
        string textBoxFilled = "";

        static Form1 form1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();

        public DropBoxPreDefined()
        {
           
        }
        public void FillTextBox()
        {
            textBoxFilled = form1.textBox1.Text;
        }

        public void FillComboBox()
        {
            foreach (string str in preSetList)
            {
                form1.comboBox1.Items.Add(str);
            }
        }

        public void ClearComboBox()
        {
            form1.comboBox1.Items.Clear();
        }
    }
}
