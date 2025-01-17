using Avalonia.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UdaltcovDemo
{
    public partial class MainWindow : Window
    {
        // Тип данных для метода Button_Click_Vxod для входа, используется как ограничитель
        bool war = true;

        private async Task isvisible()
        {
            // Проявляем через 10 сек
            await Task.Delay(10000);
            // Проявляем кнопку
            VOITI.IsVisible = true;
            guest.IsVisible = true;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // Строка с данными для капчи
        private string GenerateString(int length)
        {
            // данные для капчи
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            //Объявление
            Random random = new Random();
            // Создание массива result | length - параметр длинны
            char[] result = new char[length];

            // цмкл с ограничением "int length"
            for (int i = 0; i < length; i++)
            {
                // Для каждого эл-та строки
                int index = random.Next(chars.Length);
                // заносим данные в массив 
                result[i] = chars[index];
            }
            //возвращаем массив
            return new string(result);
        }
        // генератор капчи
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
                        string warning = "ОШИБКА! Ошибка в вводе Капчи";
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
                    string warning = "ОШИБКА! Неверный ЛОГИН ИЛИ ПАРОЛЬ!";
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
                    string warning = "ОШИБКА! Неверный ЛОГИН ИЛИ ПАРОЛЬ!";
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