using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UdaltcovDemo;

public partial class Errors : Window
{
    public Errors()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}