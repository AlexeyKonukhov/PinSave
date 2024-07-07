using Avalonia.Controls;

namespace PinSave.Views
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
        }

        private void PinsRepeater_PropertyChanged(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "ItemsSource")
                ((ItemsRepeater)sender!).Children.Clear();
        }
    }
}
