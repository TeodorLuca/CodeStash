using System.Windows;
using System.Windows.Input;

namespace CodeStash3.View
{
    /// <summary>
    /// Interaction logic for AddSnippetWindow.xaml
    /// </summary>
    public partial class AddSnippetWindow : Window
    {
        public AddSnippetWindow()
        {
            InitializeComponent();
            //CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            //binding.Executed += ExecuteOKCommand;
            //this.CommandBindings.Add(binding);


        }

        public string SnippetName
        {
            get
            {
                return textBox.Text;
            }
        }
        //private void okBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    DialogResult = true;
        //}

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    DialogResult = true;
                    break;
                case Key.Escape:
                    DialogResult = false;
                    break;
                default:
                    break;
            }
        }
    }
}
