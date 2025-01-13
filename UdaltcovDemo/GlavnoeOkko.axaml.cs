using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Data;
using UdaltcovDemo.Models;

namespace UdaltcovDemo;

public partial class GlavnoeOkko : Window
{
    User Users;
    public GlavnoeOkko()
    {
        InitializeComponent();
        Users = new User();
    }
    public GlavnoeOkko(User user)
    {
        InitializeComponent();
        Users = user;

        GlavnOkko.DataContext = Users;
        /*
        if (Users != null)
        {
            login.Text = Users.Login;
            role.Text = Users.RoleName;
        }
        else
        {
            login.Text = "Гость";
            role.Text = "Гость";
        }
        */
    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}