using Controls;
using System.Windows;

namespace Wpf_Shaders
{
    public partial class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new SomeWindow();
            window.Owner = this;

            window.ShowDialog();
        }
    }
}
