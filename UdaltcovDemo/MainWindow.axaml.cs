using Avalonia.Controls;
using System.Linq;

namespace UdaltcovDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Vxod(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var user = Helper.DateBase.Users.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Text);

            if (user != null)
            {
                GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user);
                glavnoeOkko.Show();
                Close();
            }
            else 
            {
                Errors errors = new Errors();
                errors.ShowDialog(this);
            }
        }

        private void Button_Click_guest(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var user = Helper.DateBase.Users.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Text);
            GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user);
            glavnoeOkko.Show();
            Close();
        }
    }
}