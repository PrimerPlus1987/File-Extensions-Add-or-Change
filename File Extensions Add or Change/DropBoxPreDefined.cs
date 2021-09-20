using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Extensions_Add_or_Change
{
    class DropBoxPreDefined : AddExtension
    {
        string[] preSetList = {".jpeg", ".jpg", ".mp3", ".bat", ".html", ".docx", ".txt", ".pdf", ".png" }; //Predefined ComboBox Items

        static Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault(); //Keeps current instance of Form1 so 
                                                                                                         //able to use items from it without starting new
      
        public void FillComboBox() //Method to fill combobox with prefilled list
        {
            foreach (string str in preSetList) //Loops through the preSetList to add to ComboBox
            {
                form1.comboBox1.Items.Add(str);
            }
        }
        public void SelectedDropBoxExtension(string str)
        {
            CheckFileNameExtension(); //First because using current instance of AddExtension so the current list of 
                                                   // FileNames in the class AddExtension is current and is needed for
                                                   //the second method call ExtensionAddition
            ExtensionAddition(str); //Call Method and pass it the chosen item from the comboBox
            form1.button2.Enabled = true;
        }

        public void ClearComboBox() //Clear the selected item so the combobox is not display any value
        {
            form1.comboBox1.Items.Clear();
        }
    }
}
