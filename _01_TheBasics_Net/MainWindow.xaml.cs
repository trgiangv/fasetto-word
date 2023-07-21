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

namespace _01_TheBasics_Net
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

        private void BttApply_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is : {this.TxtDescription.Text}", "Information");
        }

        private void BttReset_Click(object sender, RoutedEventArgs e)
        {
            this.CbDrill.IsChecked 
            = this.CbAssembly.IsChecked 
            = this.CbFold.IsChecked 
            = this.CbLaser.IsChecked 
            = this.CbLathe.IsChecked
            = this.CbPlasma.IsChecked 
            = this.CbPurchase.IsChecked 
            = this.CbRoll.IsChecked 
            = this.CbWeld.IsChecked
            = this.CbSaw.IsChecked = false;
        }

        private void Checkbox_checked(object sender, RoutedEventArgs e)
        {
            this.TxtLength.Text += (string)((CheckBox)sender).Content;
        }

        private void Finish_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TxtNote == null)
                return;
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            this.TxtNote.Text = (string)value.Content;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Finish_OnSelectionChanged(this.CbbFinish, null);
        }

        private void SupplierName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.TxtMass.Text = this.TxtSupplierName.Text;
        }
    }
}
