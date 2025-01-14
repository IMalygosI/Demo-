using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UdaltcovDemo;

public partial class Errors2 : Window
{
    public Errors2()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}