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

        private void OnEffectButton_Click(object sender, RoutedEventArgs e)
        {
            UseDisabledEffect = true;
        }

        private void OffEffectButton_Click(object sender, RoutedEventArgs e)
        {
            UseDisabledEffect = false;
        }
    }
}
