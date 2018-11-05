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
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;

namespace XmlLibrary {
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // flag for <txtFrom_Changed> that tells 
        // whether there is a error message printed on
        private bool txtFromErr;
        // flag for <txtTo_Changed> that tells 
        // whether there is a error message printed on
        private bool txtToErr;
        // the xml document construction
        private DataExtractor extractor;

        /**
         * Main window constructor
         */
        public MainWindow() {
            // initializate the componets
            InitializeComponent();
        }

        /**
         * Button action method
         */
        private void btnConvert_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();

            if ((bool)dialog.ShowDialog())
            {
                // load the file
                string text;

                try
                {
                    StreamReader stream = new StreamReader(dialog.OpenFile());

                    text = stream.ReadToEnd();
                }
                catch
                {
                    MessageBox.Show("File di input non trovato");
                    return;
                }

                // check for empty file
                if (String.IsNullOrEmpty(text))                
                    MessageBox.Show("The file doesn't contains any text");
                else
                    // load into the extractor
                    extractor = new DataExtractor(XDocument.Parse(text));
            }
        }

        private void btnSAuth_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text != String.Empty)            
                // check using the author
                lblOutput.Content = extractor.GetTitleByAuthor(txtMod.Text);
            
        }

        private void btnCTitle_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text != String.Empty)            
                // count the titles
                lblOutput.Content = extractor.GetCopiesBytitle(txtMod.Text).ToString();
            
        }

        private void btnCGender_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text != String.Empty)
                // count the genre
                lblOutput.Content = extractor.GetNumberByGivenGenre(txtMod.Text).ToString();
        }

        private void btnRAbstract_Click(object sender, RoutedEventArgs e)
        {
            // remove the abstracts
            extractor.RemoveAbstract();
            lblOutput.Content = "Done";
        }

        private void btnMGender_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            int sepndx = txtMod.Text.IndexOf(" => ");

            if (txtMod.Text != String.Empty && sepndx >= 0)
            {
                // get the input
                string title = txtMod.Text.Substring(0, sepndx);

                string ngendre = txtMod.Text.Substring(sepndx + 4);

                // modify
                extractor.ChangeGenreByTitle(title, ngendre);
                lblOutput.Content = "Done";
            }
        }

        private void btnNLibShort_Click(object sender, RoutedEventArgs e)
        {
            extractor.MakeSubset("");
            lblOutput.Content = "Done";
        }

        /**
         * Text changed event for <txtFrom> textfield
         */
        private void txtFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblFrom.Foreground = Brushes.Black;
            lblFrom.Content = "From";
        }

        /**
         * Text changed event for <txtTo> textfield
         */
        private void txtTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblTo.Foreground = Brushes.Black;
            lblTo.Content = "To";
        }
    }
}
