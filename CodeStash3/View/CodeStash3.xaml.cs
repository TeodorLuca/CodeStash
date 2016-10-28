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

        public bool snippetChanged { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            //ICodeStash3ViewModel viewModelIF = new CodeStash3ViewModel();
            this.DataContext = viewModelIF;
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //binding.Executed += viewModelIF.AddCommand;
            binding.Executed += AddCommand;
            this.CommandBindings.Add(binding);

        }

        private void AddCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AddSnippetWindow dialogWin = new AddSnippetWindow();
            if (dialogWin.ShowDialog().Value == true)
            {
                viewModelIF.AddSnippet(dialogWin.SnippetName);
                
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (snippetChanged)
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
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            snippetChanged = false;

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            snippetChanged = true;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(snippetChanged)
            {
                viewModelIF.SaveSnippet();
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
}
