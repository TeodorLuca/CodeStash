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
using CodeStash3.ViewModel;
using CodeStash3.BLL;
using CodeStash3.View;
using System.Globalization;

namespace CodeStash3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICodeStash3ViewModel viewModelIF = new CodeStash3ViewModel();
        private string language;
        private bool codeCanChange;
        private bool languageCanChange;

        public bool codeChanged { get; private set; }
        public bool languageChanged { get; private set; }


        public MainWindow()
        {
            InitializeComponent();

            //ICodeStash3ViewModel viewModelIF = new CodeStash3ViewModel();
            this.DataContext = viewModelIF;
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //binding.Executed += viewModelIF.AddCommand;
            binding.Executed += AddCommand;
            this.CommandBindings.Add(binding);
            codeChanged = false;
            codeCanChange = false;
            languageChanged = false;
            languageCanChange = false;
        }

        private void AddCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AddSnippetWindow dialogWin = new AddSnippetWindow();
            if (dialogWin.ShowDialog().Value == true)
            {
                viewModelIF.AddSnippet(dialogWin.SnippetName);

            }
        }

        private void SaveSnippetDialog()
        {
            MessageBoxResult result = MessageBox.Show(this, "Save changes?", "Save snippet", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                viewModelIF.SaveSnippet();
            }
            else
            {
                viewModelIF.DiscardChanges();
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            codeCanChange = true;
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (codeCanChange)
                codeChanged = true;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            codeCanChange = false;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (codeChanged | languageChanged)
            {
                viewModelIF.SaveSnippet();
                codeChanged = false;
                languageChanged = false;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            viewModelIF.DeleteSnippet();
        }

        private void languageComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ComboBox combo = (sender as ComboBox);
                if (!combo.Items.Contains(combo.Text))
                {
                    viewModelIF.AddLanguage((sender as ComboBox).Text);
                    viewModelIF.ChangeLanguage((sender as ComboBox).Text);
                    languageChanged = true;
                }

            }

        }

        private void languageComboBox_DropDownOpened(object sender, EventArgs e)
        {
            language = (sender as ComboBox).Text;
            languageCanChange = true;
        }

        private void languageComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (language != (sender as ComboBox).Text)
            {
                viewModelIF.ChangeLanguage((sender as ComboBox).Text);
                languageChanged = true;
            }
                
            languageCanChange = false;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SnippetChanged())
            {
                SaveSnippetDialog();
            }
        }



        private bool SnippetChanged()
        {
            if (codeChanged | languageChanged)
            {
                codeChanged = false;
                languageChanged = false;
                return true;
            }
            return false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SnippetChanged())
            {
                SaveSnippetDialog();
            }

        }
    }

    public class noConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class stringBuilderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class nullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = value != null;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class LanguageToIndexConverter : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return -1;
            //string language = (values[0] as Snippet).Language;
            string language = values[0] as string;
            ItemCollection value = values[1] as ItemCollection;
            string[] languagesList = new string[value.Count];
            value.CopyTo(languagesList, 0);
            return Array.IndexOf(languagesList, language);

        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //int index = (int)value;

            //Snippet selectedSnippet = viewModelIF.sele    //new Snippet();
            //string language = (values[0] as Snippet).Language;

            //return new object[2] {null, null };
            return null;

        }

    }

}
