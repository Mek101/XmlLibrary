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

namespace XmlLibrary
{
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
        public MainWindow()
        {
            // initializate the componets
            InitializeComponent();
            txtFrom.Text = @".\..\..\..\libri.XML";
            //txtMod.Text = "Primo";
            btn_Load_Click(this, null);
        }

        /**
         * Loads the xml library
         */
        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            // get the text into the two textboxes
            if (String.IsNullOrEmpty(txtFrom.Text))
            {
                MessageBox.Show("No path!");
            }
            else
            {
                // load the file
                string text;
                try
                {
                    text = File.ReadAllText(txtFrom.Text, Encoding.UTF8);
                }
                catch
                {
                    MessageBox.Show("File di input non trovato");
                    return;
                }

                // check for empty file
                if (String.IsNullOrEmpty(text))
                    MessageBox.Show(txtFrom.Text + " doesn't contains any text");
                else
                {
                    // load into the extractor
                    extractor = new DataExtractor(XDocument.Parse(text));
                    MessageBox.Show("Caricato con successo!");

                    //MessageBox.Show(extractor.Dump());
                }
            }
        }

        /**
         * Button action method
         */
        private void btnSAuth_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text == String.Empty)
                MessageBox.Show("No input!");
            else
            {
                // check using the author
                IEnumerable<string> titles = extractor.GetTitleByAuthor(txtMod.Text);

                lst_output.Items.Add("Trovati " + titles.Count() + " autori.");

                foreach (string str in titles)
                    lst_output.Items.Add(str);
            }
        }

        /**
         * Button action method
         */
        private void btnCTitle_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text == String.Empty) return;

            // count the titles
            lst_output.Items.Add(extractor.GetCopiesBytitle(txtMod.Text).ToString());
        }

        /**
         * Button action method
         */
        private void btnCGender_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text == String.Empty) return;

            // count the genre
            lst_output.Items.Add(extractor.GetNumberByGivenGenre(txtMod.Text).ToString());
        }

        /**
         * Button action method
         */
        private void btnRAbstract_Click(object sender, RoutedEventArgs e)
        {
            // remove the abstracts
            extractor.RemoveAbstract();
            lst_output.Items.Add("Done");
        }

        /**
         * Button action method
         */
        private void btnMGender_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            int sepndx = txtMod.Text.IndexOf(" => ");

            if (txtMod.Text != String.Empty && sepndx >= 0)
            {
                // get the input
                var title = txtMod.Text.Substring(0, sepndx);
                var ngender = txtMod.Text.Substring(sepndx + 4);
                // modify
                extractor.ChangeGenreByTitle(title, ngender);
                lst_output.Items.Add("Done");
            }
        }

        /**
         * Button action method
         */
        private void btnNLibShort_Click(object sender, RoutedEventArgs e)
        {
            // get the content of the input text
            if (txtMod.Text == String.Empty) return;

            extractor.MakeSubset(txtMod.Text);
            lst_output.Items.Add("Done");
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


        private void btn_save_Click(object sender, RoutedEventArgs e) { extractor.SaveDocument(); }
    }
}
