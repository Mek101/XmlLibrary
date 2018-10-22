﻿using System;
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
            // get the text into the two textboxes
            if (String.IsNullOrEmpty(txtFrom.Text) || String.IsNullOrEmpty(txtTo.Text)) {
                // get the label first
                Label label = (
                    // check wich textfield is empty
                    txtFrom.Text == String.Empty ? 
                    // so get its label
                    lblFrom : 
                    lblTo
                );
                // assign the color red for the error
                label.Foreground = Brushes.Red;
                // put the error message now
                label.Content = "Missing path";
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
