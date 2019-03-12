//
// FILE : About.xaml.cs
// PROJECT : PROG2120 - Assignment #2
// PROGRAMMER : Attila Katona
// FIRST VERSION : 2018-10-08
// DESCRIPTION : The source code for the logic of the About.xaml. The file initilizes the about window with information
//               about the program Assignment2.
//  
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
using System.Windows.Shapes;

namespace Assignment2
{
    // NAME : About
    // PURPOSE : The about window class will generate a new window that can be accessed through
    //           a button click. It will display some information about the program and display
    //           a "okay" button that will close the window.
    //
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        //
        // FUNCTION : Button_Click
        //
        // DESCRIPTION : Handles the button click for the OKAY button on mainpage
        //
        // PARAMETERS : Object sender - contains a reference to the control/object that raised the event
        //
        //              CancelEventArgs e - Provides data for a cancelable event. A cancelable event is 
        //              raised by a component when it is about to perform an action that can be canceled
        //              (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs?view=netframework-4.7.2)
        //
        // RETURNS : None
        //
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
