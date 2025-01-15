using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UdaltcovDemo;

public partial class Errors3 : Window
{
    public Errors3()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}