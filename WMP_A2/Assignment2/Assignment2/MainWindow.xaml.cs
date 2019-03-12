//
// FILE : MainWindow.xaml.cs
// PROJECT : PROG2120 - Assignment #2
// PROGRAMMER : Attila Katona
// FIRST VERSION : 2018-10-08
// DESCRIPTION : The source code for the logic of the MainWindow.xaml. This program holds all the classes,
//               methods and variables needed to make the WPF application perform the way it is meant to. This program
//               will act like a text editor modeled after "notepad" from Microsoft. It will allow the user to input 
//               text into a textbox. It will display the number of characters on screen in the bottom left hand corner.
//               It will allow users to save, open and start a new file. All files saved and opened will be in the *.txt
//               format. There is a change font and style feature located under the options menu. All file save/open options
//               are located under the "file" menu and information about the program is located under the "About" option.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //
        // FUNCTION : Window_Closing
        //
        // DESCRIPTION : Handles the button click for "x" and file->close
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              CancelEventArgs e - Provides data for a cancelable event. A cancelable event is 
        //              raised by a component when it is about to perform an action that can be canceled
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        public void Window_Closing(object sender, CancelEventArgs e)
        {
            //Below is calling the message box class that has multiple buttons which can be chosen by the user
            MessageBoxResult answer = System.Windows.MessageBox.Show("Are you sure you would like to exit?", "Exit", MessageBoxButton.YesNo);
            switch (answer)
            {
                case MessageBoxResult.Yes:
                    {
                        this.Close();
                        break;
                    }
                case MessageBoxResult.No:
                    {
                        e.Cancel = true;
                        break;
                    }
            }

        }
        //
        // FUNCTION : txtBox_TextChanged
        //
        // DESCRIPTION : Displays the count of characters on the screen input by the user
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              TextChangedEvenArgs - Provides data for the TextChanged event.
        //              (https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textchangedeventargs)
        //
        // RETURNS : None
        //
        public void txtBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            statusTxt.Text = txtBox.Text.Length.ToString();
        }
        //
        // FUNCTION : SaveAs_Click
        //
        // DESCRIPTION : Handles the "Save As" option found under "File" tab. Wil save the whatever is written inside
        //               the text box to a .txt file. Only if textbox is NOT empty.
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text Files |*.txt";
            if(SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Show the directory structure
            {
                File.WriteAllText(SFD.FileName, txtBox.Text);
            }
            else
            {
                System.Windows.MessageBox.Show("ERROR SAVING-TRY AGAIN");
            }
            
        }
        //
        // FUNCTION : Open_Click
        //
        // DESCRIPTION : Handles the "Open" option found under "File" tab. Will display directory structure and allow
        //               user to choose a *txt file to open and edit.
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Text Files |*.txt";
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = File.ReadAllText(OFD.FileName);
            }
            else
            {
                System.Windows.MessageBox.Show("ERROR OPENING-TRY AGAIN");
            }

        }
        //
        // FUNCTION : New_Click
        //
        // DESCRIPTION : Handles the "New" option found under "File" tab. Will ask user to save whatever has been entered
        //               into the text box only if it is NOT empty. Otherwise it will clear the textbox to blank and allow
        //               user to enter new text.
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text != "")//Check to make sure the textbox is NOT empty
            {
                MessageBoxResult answer = System.Windows.MessageBox.Show("Would you like to save the file before opening a new one?", "Save File", MessageBoxButton.YesNoCancel);
                switch (answer)
                {
                    case MessageBoxResult.Yes:
                    {
                        SaveAs_Click(sender, e);
                        txtBox.Text = "";
                        break;
                    }
                    case MessageBoxResult.No:
                    {
                        txtBox.Text = "";
                        break;
                    }
                    case MessageBoxResult.Cancel:
                    {
                        break;
                    }
                }
                       
            }
        }
        //
        // FUNCTION : Exit_Click
        //
        // DESCRIPTION : Handles the "Exit" option found under "File" tab. Closes the program.
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //
        // FUNCTION : About_Click
        //
        // DESCRIPTION : Handles the "About" option found under "Help" tab. Will display a window that will display
        //               information about the program including name, author, date , version and a brief discription.
        //               Uses borrowed code and a seperte file called About.xaml for the window construction
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void About_Click(object sender, RoutedEventArgs e)
        {
            //Below code "borrowed" from WpfApp1 found on K:\nmika\ on the school network
            About ab = new About();
            ab.Owner = System.Windows.Application.Current.MainWindow;
            ab.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ab.ShowDialog();
        }
        //
        // FUNCTION : Format_Click
        //
        // DESCRIPTION : Handles the "Format" option found under "Options" tab. The option will open the font dialogue
        //               window and allow the user to change the font, size, and style of the input text.
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              RoutedEventArgs e - Contains state information and event data associated with a routed event.
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.windows.routedeventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void Format_Click(object sender, RoutedEventArgs e)
        {
            FontDialog FD = new FontDialog();

            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Show the font dialogue window
            {
                txtBox.FontFamily = new FontFamily(FD.Font.Name);
            }

        }
    }
}
