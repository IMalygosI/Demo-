using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UdaltcovDemo.Models;

namespace UdaltcovDemo;

public partial class GlavnoeOkko : Window
{
    List<ConstructionMaterial> constructionMaterials = new List<ConstructionMaterial>();
    List<Manufacturer> manufacturers = new List<Manufacturer>();
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
        if (Users != null)
        {
            First_Name.Text = Users.FirstName;
            name.Text = Users.Name;
            Patronymic.Text = Users.Patronical;
        }
        else
        {
            First_Name.Text = "Гость";
        }

        PriceCoboBox.SelectionChanged += PriceCoboBox_SelectionChanged;
        ManufacturerBox.SelectionChanged += ManufacturerBox_SelectionChanged;

        LoangManufacturer();
        Loang();
    }

    public void LoangManufacturer()
    {
        manufacturers = Helper.DateBase.Manufacturers.ToList();
        manufacturers.Add(new Manufacturer() { Name = "Все производители" });
        ManufacturerBox.ItemsSource = manufacturers.OrderByDescending(a => a.Name == "Все производители");
        ManufacturerBox.SelectedIndex = 0;
    }

    public void Loang()
    {
        constructionMaterials = Helper.DateBase.ConstructionMaterials.Include(c => c.MmanufacturerNavigation).ToList();

        if (PriceCoboBox.SelectedIndex == 1)
        {
            constructionMaterials = constructionMaterials.OrderByDescending(z => z.Price).ToList();
        }
        else if (PriceCoboBox.SelectedIndex == 2)
        {
            constructionMaterials = constructionMaterials.OrderBy(z => z.Price).ToList();
        }

        if (ManufacturerBox.SelectedIndex > 0)
        {
            var Manufacturerss = (Manufacturer)ManufacturerBox.SelectedItem;
            constructionMaterials = constructionMaterials.Where(f => f.Mmanufacturer == Manufacturerss.ManufacturerId).ToList();
        }

        var seatch = (TextSearch.Text ?? "").Split(' ');
        constructionMaterials = constructionMaterials.Where(z => seatch.All(s => z.Name.Contains(s) ||
                                                                                 z.Description.Contains(s) ||
                                                                                 z.Price.ToString().Contains(s) ||
                                                                                 z.Count.ToString().Contains(s) ||
                                                                                 z.Mmanufacturer.ToString().Contains(s)
                                                                                 )).ToList();

        baza.Text = Helper.DateBase.ConstructionMaterials.ToList().Count().ToString();
        online.Text = constructionMaterials.Count.ToString();

        ListBox_GlavOkko.ItemsSource = constructionMaterials;
    }
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
    private void PriceCoboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();
    private void ManufacturerBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();

    private void Button_Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RedactOkkoAndDobavit redactOkkoAndDobavit = new RedactOkkoAndDobavit(Users);
        redactOkkoAndDobavit.Show();
        Close();
    }

    private void Button_Click_Delete_Tovar(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var deletTovar = ListBox_GlavOkko.SelectedItem as ConstructionMaterial;

        bool isInCart = false;

        foreach (var order in Helper.DateBase.Orders)
        {
            var articles = order.OrderSostav.Split(',');

            // Проверяем, содержится ли артикул удаляемого товара в списке артикулов
            if (articles.Contains(deletTovar.Article))
            {
                isInCart = true;
                break;
            }
        }

        if (isInCart)
        {
            Errors2 errors = new Errors2();
            errors.ShowDialog(this);
        }
        else
        {
            Helper.DateBase.ConstructionMaterials.Remove(deletTovar);
            Helper.DateBase.SaveChanges();
            Loang();
        }
    }
}