using Avalonia.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UdaltcovDemo
{
    public partial class MainWindow : Window
    {
        // ��� ������ ��� ������ Button_Click_Vxod ��� �����, ������������ ��� ������������
        bool war = true;

        private async Task isvisible()
        {
            // ��������� ����� 10 ���
            await Task.Delay(10000);
            // ��������� ������
            VOITI.IsVisible = true;
            guest.IsVisible = true;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // ������ � ������� ��� �����
        private string GenerateString(int length)
        {
            // ������ ��� �����
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            //����������
            Random random = new Random();
            // �������� ������� result | length - �������� ������
            char[] result = new char[length];

            // ���� � ������������ "int length"
            for (int i = 0; i < length; i++)
            {
                // ��� ������� ��-�� ������
                int index = random.Next(chars.Length);
                // ������� ������ � ������ 
                result[i] = chars[index];
            }
            //���������� ������
            return new string(result);
        }
        // ��������� �����
        private void UpdateCaptcha()
        {
            string randomText = GenerateString(4);
            captcha.Text = randomText;
        }

        private void Button_Click_Vxod(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var user = Helper.DateBase.Users.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Text);

            if (war != true)
            {
                if (user != null)
                {
                    if (captcha.Text != null && captcha.Text != null && captcha.Text == Captcha.Text)
                    {
                        GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user);
                        glavnoeOkko.Show();
                        Close();

                        captcha.IsVisible = false;
                        Captcha.IsVisible = false;
                    }
                    else
                    {
                        string warning = "������! ������ � ����� �����";
                        Errors errors = new Errors(warning);
                        errors.ShowDialog(this);

                        VOITI.IsVisible = false;
                        guest.IsVisible = false;
                        isvisible();
                        UpdateCaptcha();
                    }
                }
                else
                {
                    string warning = "������! �������� ����� ��� ������!";
                    Errors errors = new Errors(warning);
                    errors.ShowDialog(this);
                }
            }
            else 
            {
                if (user != null)
                {
                    GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user);
                    glavnoeOkko.Show();
                    Close();
                }
                else
                {
                    string warning = "������! �������� ����� ��� ������!";
                    war = false;
                    Errors errors = new Errors(warning);
                    errors.ShowDialog(this);

                    captcha.IsVisible = true;
                    Captcha.IsVisible = true;
                    UpdateCaptcha();
                }
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