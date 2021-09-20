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
        string extensionName;
        string textBoxedFilled;
        string FilePathOfSelectedFiles;

        List<string> FullPathOfAllFiles = new List<string>(); //Holds all Path and file names of all selected files
        List<string> selectedFileNames = new List<string>(); //Holds the File names
        List<string> ViewAllChangedFiles = new List<string>(); //Holds file names and extensions

        static Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault(); //Holds current instance of Form1 so able to  
                                                                                                          //use items from it without starting new

        
        public void ThisIsTheFIlePathOfFiles(string dirName, string fulllPath, string fileNameWithExtOnly)//Method to pass values for use
        {
            FilePathOfSelectedFiles = dirName; //Directory Name
            FullPathOfAllFiles.Add(fulllPath); //Full path including directory nanme and ext
            ViewAllChangedFiles.Add(fileNameWithExtOnly); //FIle name and extension only

        }

        public void StartTheChange() //Method to rename the file with the chosen extension
        {
            try
            {
                DisableTheButtons(); //Call method to disablebuttons so not able to change after file extension has been renamed

                for (int i = 0; i < selectedFileNames.Count; i++) //Loop through all selected files
                {
                    form1.listView4.Items.Add(ViewAllChangedFiles[i]); //update listview with all files changed

                    File.Move(FullPathOfAllFiles[i], FilePathOfSelectedFiles + "\\" + selectedFileNames[i] + extensionName, true); //Use the Move method to rename 
                                                                                                                                   //the file and put in same location

                    form1.listView3.Items.Add(selectedFileNames[i] + extensionName); //Display the file with the new extension
                }
                FullPathOfAllFiles.Clear(); //Make sure list is now empty
                selectedFileNames.Clear(); //make sure list is now empty
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       public List<string> CheckFileNameExtension() //Checks if the file has an extension or not
        {
            List<string> altered = new List<string>(); //LIst to hold changed files

            for (int i = 0; i < selectedFileNames.Count; i++) //Loop through all selected files
            {
                if(selectedFileNames[i].Contains(".")) //Check if the current selected file has a "." 
                {
                    int index = selectedFileNames[i].IndexOf("."); //Get the current index of the "." and store its value

                    StringBuilder sb = new StringBuilder(selectedFileNames[i]); //Use instance of stringbuilder for each file

                    sb.Remove(index, selectedFileNames[i].Length - index); //Remove the "." from the file that has it & start it at the position of where it is seen
                                                                           //Remove everything after the start of it so to delete the extension as well
                   
                    altered.Add(sb.ToString()); //Add all new files to the List
                }
                else
                {
                    altered.Add(selectedFileNames[i]); //If no "." in file name add file to the altered List
                }
            }

            selectedFileNames = altered; //Pass the altered List back to the selectedFileNames List

            return selectedFileNames; //Return the List back for use
        }


        public string CheckTheString() //Checks if the user input follows the rules
        {
            CheckFileNameExtension(); //Call method to check the file name extension
            try
            {
                textBoxedFilled = '.' + form1.textBox1.Text; //Add a "." just to be sure there is one included if the file has no "."

                if (textBoxedFilled[1] == '.') //IF there is a "." in the 2nd position (index 1) of the string the do the following
                {
                    StringBuilder sb = new StringBuilder(textBoxedFilled); //Create an instance of the stringbuilder for textBoxedFilled string

                    sb.Remove(0, 1); //This will remove one character starting at index 0 of the string
                                     //Becaues if in this if statement then there must be 2 occurrences of "."

                    textBoxedFilled = sb.ToString(); //Take new string and send to string textBoxedFIlled

                    form1.button2.Enabled = true; //Activate the button2 (Start Button)

                    return textBoxedFilled; //Send back the new string
                }

                else //Check if the user entered a ".", if not send a warning
                {
                    MessageBox.Show("You must use a '.' before declaring your extension.");
                    form1.textBox1.Clear(); //Erase what the user entered to start over
                }
            }
            catch
            {
                MessageBox.Show("You must enter an extension.");
            }

            return ""; //Return an empty string if wrong input was entered
        }

        public void ExtensionAddition(string str) //Method to get the chose extension
        {
            extensionName = str; //Store the extension
            CombineThem(); //Call Method 
        }

        public void NameOfFIles(List<string> str) //Store the list of files
        {
            selectedFileNames = str;
        }

        public void CombineThem() //Method that displays the current selected files with the chosen extension name
        {
            form1.listView2.Items.Clear();
            foreach (string file in selectedFileNames)
            {
                form1.listView2.Items.Add(file + extensionName);
            }
        }

       static public void DisableTheButtons() //Method that disables all the buttons and comboboxe 
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

        public void ClearTheScreen() //Method that clears everything that is non important for the current task
        {
            FullPathOfAllFiles.Clear();
            selectedFileNames.Clear();
            ViewAllChangedFiles.Clear();
            form1.namesOfFiles.Clear(); //Clear list of names incase of changing the selected files
            form1.listView1.Items.Clear();
            form1.listView2.Items.Clear();
            form1.listView3.Items.Clear();
        }

    }
}
