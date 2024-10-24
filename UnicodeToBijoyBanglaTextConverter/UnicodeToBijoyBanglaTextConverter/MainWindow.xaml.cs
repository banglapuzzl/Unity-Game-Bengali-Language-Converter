using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnicodeToBijoyBanglaTextConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "Unicode থেকে বিজয়ের বাংলা লেখার Converter";
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = this.InputTextbox.Text.Trim();
            
            if (inputText.Length > 0)
            {
                this._convert(inputText);
            }
            else
            {
                this._showAlert("Warning", "আপনি সম্পূর্ণ input দেন নাই", MessageBoxImage.Warning);
            }
        }

        private void _showAlert(string title, string content, MessageBoxImage icon)
        {
            string messageBoxText = content;
            string caption = title;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
        }

        private void _convert(string inputText)
        {
            string output = ConverterTools.GetAsciiBengaliFromUnicodeText(inputText);

            this.OutputTextbox.AppendText(output);
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            string output = this.OutputTextbox.Text.Trim();

            if (output.Length > 0)
            {
                Clipboard.SetText(output);

                this._showAlert("Copied", "লেখা clipboard এ copy করা হয়েছে", MessageBoxImage.Information);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.InputTextbox.Text = string.Empty;
            this.OutputTextbox.Text = string.Empty;
        }

        private void OutputTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string output = this.OutputTextbox.Text.Trim();

            this.CopyButton.IsEnabled = (output.Length > 0);
        }
    }
}