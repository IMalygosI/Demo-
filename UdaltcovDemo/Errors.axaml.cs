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
        if (Warnings == "������! �������� �������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������! ������ � ����� �����")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������! �������� ����� ��� ������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������! ������ �� ����� ���� ��������������!")
        {
            Warning.Text = Warnings;
        }
        if (Warnings == "������! �������� ������ ��. ���������! ������� � (��.)!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ����� � ������� ������� ������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ���� � ���������� �� ����� ���� ��������������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ������� ��� ����� ��� �����������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! �� �� ������� �������������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! �� �� ������� ����������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ������� ������������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ������� ������� ���������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! �� �� ������� ������������ ������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ������� ����!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ������� ����������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! �� �� ������� ���������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! �� �� ������� ����������� ������!")
        {
            Warning.Text = Warnings;
        }
        else if (Warnings == "������! ��������� ������ �� ����� ���� ������ ��� ����� ������������!")
        {
            Warning.Text = Warnings;
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}