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
using System.IO;
using System.Timers;
using System.Windows.Threading;

namespace XmlLibrary {
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // the timer used when need to put an 
        // "asyncronous" message on a label, like an error
        private DispatcherTimer timer;

        /**
         * Prints on the label <l> the message <msg> with the given color <col>
         * 
         * @param l:        the label where print
         * @param msg:      the message to print
         * @param col:      the color of the message
         */
        private void AsyncMessageOn(Label l, string msg, Brushes col) {

        }

        /**
         * Main window constructor
         */
        public MainWindow() {
            // initializate the componets
            InitializeComponent();
            // create the timer
            timer = new DispatcherTimer();
        }

        /**
         * Button action method
         */
        private void btnConvert_Click(object sender, RoutedEventArgs e) {
            // get the text into the two textboxes
            if (String.IsNullOrEmpty(txtFrom.Text) || String.IsNullOrEmpty(txtTo.Text)) {
                // show outsise a message to warn the user
                var label = (txtFrom.Text == String.Empty ? txtFrom : txtTo);
                label.Foreground = Brushes.Red;
                string old = label.Text;
                label.Text = "Missing path";
                return;
            }

            // load the file
            string text = File.ReadAllText(txtFrom.Text, Encoding.UTF8);
            if (String.IsNullOrEmpty(text)) {
                MessageBox.Show(txtFrom.Text + " doesn't contains any text");
                return;
            }
        }

        /**
         * Text changed event for <txtFrom> textfield
         */
        private void txtFrom_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
