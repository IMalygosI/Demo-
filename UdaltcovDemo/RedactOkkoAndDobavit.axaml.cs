using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UdaltcovDemo.Models;

namespace UdaltcovDemo;

public partial class RedactOkkoAndDobavit : Window
{
    User user1;
    public RedactOkkoAndDobavit()
    {
        InitializeComponent();
        user1 = new User();
    }
    public RedactOkkoAndDobavit(User user)
    {
        InitializeComponent();
        user1 = user;
    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user1);
        glavnoeOkko.Show();
        Close();
    }
}