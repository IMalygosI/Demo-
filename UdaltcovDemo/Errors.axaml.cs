using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace UdaltcovDemo;

public partial class Errors : Window
{
    public Errors()
    {
        InitializeComponent();
    }

    public Errors(string Warnings)
    {
        InitializeComponent();
        if (Warnings == "ОШИБКА! Добавьте Артикул!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "ОШИБКА! Ошибка в вводе Капчи")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "ОШИБКА! Неверный ЛОГИН ИЛИ ПАРОЛЬ!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "ОШИБКА! Скидки не могут быть отрицательными!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "ОШИБКА! Неверный формат Ед. Измерения! Укажите в (шт.)!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Товар в крозине удалить нельзя!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Цена и количество не могут быть отрицательными!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Артикул уже занят или отсутствует!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Вы не выбрали производителя!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Вы не выбрали Поставщика!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Укажите Наименование!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Укажите единицу измерения!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Вы не указали Максимальную скидку!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Укажите цену!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Укажите количество!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Вы не выбрали Категорию!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Вы не указали действующую скидку!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "ОШИБКА! Настоящая скидка не может быть больше или равна Максимальной!")
        {
            Warning.Text = Warnings;
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}