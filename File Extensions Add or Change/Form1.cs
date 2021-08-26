using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace File_Extensions_Add_or_Change
{
    public partial class Form1 : Form
    {
        
        public List<string> namesOfFiles = new List<string>();

        AddExtension AddExtension = new AddExtension(); //Creates instance of the AddExtension Class
        DropBoxPreDefined DropBoxPreDefined = new DropBoxPreDefined(); //Creates instance of the DropBoxPreDefined class

        public Form1()
        {
            InitializeComponent();
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            //Select Files Button

            DialogResult dr = openFileDialog1.ShowDialog(); //Opens file Selection box
            
            AddExtension.ClearTheScreen(); //Clears all non important screens and empties lists

            if (dr == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    string fileNames = Path.GetFileName(file); //Gets name of files with extension only

                    string fileFullPath = Path.GetFullPath(file); //Get entire path of the file with extension

                    string pathName = Path.GetDirectoryName(fileFullPath); //Get only the Directory of the file

                    AddExtension.ThisIsTheFIlePathOfFiles(pathName, fileFullPath, fileNames); //Call the method and pass in the above values
                    
                    listView1.Items.Add(fileNames); //Display the selected files
                    namesOfFiles.Add(fileNames); //add the files to a List for later use
                }
            }
            openFileDialog1.FileName = ""; //Make the dialog box for file selection empty each time its loaded.

            radioButton1.Enabled = true; //activate the radio buttons once files selcted
            radioButton2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                AddExtension.NameOfFIles(namesOfFiles); //Call the Method and pass it the list of file names
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
                AddExtension.NameOfFIles(namesOfFiles); //Call Method and pass it the list of file names
                DropBoxPreDefined.FillComboBox(); //Call method that populates the combo boc
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
            if (e.KeyCode == Keys.Enter) //Checks if the enter button is pressed after filling in the text box with user input
            {
                AddExtension.ExtensionAddition(AddExtension.CheckTheString()); //Call 2 methods passing the return value to the next
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1) //Checks if the combobox has a selected value if not do nothing
            {
                string selectedComboBoxExt = comboBox1.SelectedItem.ToString(); //Puts the selected value to a string value
                DropBoxPreDefined.CurrentInstanceOfAddExtension(AddExtension); //Calls method and passes the current instance of the AddExtension class so
                                                                                //not to start with a clean instance of it causing issues

                DropBoxPreDefined.SelectedDropBoxExtension(selectedComboBoxExt); //Calls method and passes the selected item from dropbox
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //start button

            AddExtension.StartTheChange(); //Calls Method to start changing the file extension
            namesOfFiles.Clear(); //Clears the list of names to be sure no storing of previous files
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Exit button

            this.Close(); //Close the program
        }

       
    }
}
