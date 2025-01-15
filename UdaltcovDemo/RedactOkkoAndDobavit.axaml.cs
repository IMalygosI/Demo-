using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tmds.DBus.Protocol;
using UdaltcovDemo.Models;

namespace UdaltcovDemo;

public partial class RedactOkkoAndDobavit : Window
{
    User user1;
    ConstructionMaterial constructionMaterial1;
    List<Manufacturer> manufacture = new List<Manufacturer>();
    List<Supplier> supplier = new List<Supplier>();
    List<ProductCategory> productCategory = new List<ProductCategory>();
    public RedactOkkoAndDobavit()
    {
        InitializeComponent();
        user1 = new User();
        constructionMaterial1 = new ConstructionMaterial();
    }
    public RedactOkkoAndDobavit(User user)
    {
        InitializeComponent();
        user1 = user;
        constructionMaterial1 = new ConstructionMaterial();
        Okko.DataContext = constructionMaterial1;
        Loang_ComboBoxManufacturer();
        Loang_ComboBoxSupplier();
        Loang_ComboBoxProductCategoryId();
    }
    public RedactOkkoAndDobavit(User user, ConstructionMaterial constructionMaterial)
    {
        InitializeComponent();
        user1 = user;
        constructionMaterial1 = constructionMaterial;
        Okko.DataContext = constructionMaterial1;

        Loang_ComboBoxManufacturer();
        Loang_ComboBoxSupplier();
        Loang_ComboBoxProductCategoryId();
    }

    public void Loang_ComboBoxManufacturer()
    {
        if (constructionMaterial1.ConstructionMaterials != 0)
        {
            manufacture = Helper.DateBase.Manufacturers.ToList();
            ComboBox_Mmanufacturer.ItemsSource = manufacture.OrderByDescending(z => z.ManufacturerId == constructionMaterial1.Mmanufacturer);
            ComboBox_Mmanufacturer.SelectedIndex = 0;

            ID.IsVisible = true;
            TextId.IsVisible = true;
        }
        else
        {
            manufacture = Helper.DateBase.Manufacturers.ToList();
            manufacture.Add(new Manufacturer() { Name = "Производители" });
            ComboBox_Mmanufacturer.ItemsSource = manufacture.OrderByDescending(s => s.Name == "Производители");
            ComboBox_Mmanufacturer.SelectedIndex = 0;
        }
    }
    public void Loang_ComboBoxSupplier()
    {
        if (constructionMaterial1.ConstructionMaterials != 0)
        {
            supplier = Helper.DateBase.Suppliers.ToList();
            ComboBox_Supplier.ItemsSource = supplier.OrderByDescending(z => z.SupplierId == constructionMaterial1.Supplier);
            ComboBox_Supplier.SelectedIndex = 0;
        }
        else
        {
            supplier = Helper.DateBase.Suppliers.ToList();
            supplier.Add(new Supplier() { Name = "Поставщики" });
            ComboBox_Supplier.ItemsSource = supplier.OrderByDescending(s => s.Name == "Поставщики");
            ComboBox_Supplier.SelectedIndex = 0;
        }
    }
    public void Loang_ComboBoxProductCategoryId()
    {
        if (constructionMaterial1.ConstructionMaterials != 0)
        {
            productCategory = Helper.DateBase.ProductCategories.ToList();
            ComboBox_ProductCategoryId.ItemsSource = productCategory.OrderByDescending(z => z.ProductCategoryId == constructionMaterial1.ProductCategoryId);
            ComboBox_ProductCategoryId.SelectedIndex = 0;
        }
        else
        {
            productCategory = Helper.DateBase.ProductCategories.ToList();
            productCategory.Add(new ProductCategory() { Name = "Категории" });
            ComboBox_ProductCategoryId.ItemsSource = productCategory.OrderByDescending(s => s.Name == "Категории");
            ComboBox_ProductCategoryId.SelectedIndex = 0;
        }
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (constructionMaterial1.ConstructionMaterials != 0)
        {
            if (ComboBox_Mmanufacturer.SelectedItem is Manufacturer MANIFACTURER)
            {
                constructionMaterial1.Mmanufacturer = MANIFACTURER.ManufacturerId;
            }
            if (ComboBox_Supplier.SelectedItem is Supplier SUPPLIER)
            {
                constructionMaterial1.Supplier = SUPPLIER.SupplierId;
            }
            if (ComboBox_ProductCategoryId.SelectedItem is ProductCategory PRODUCTCATEGORY)
            {
                constructionMaterial1.ProductCategoryId = PRODUCTCATEGORY.ProductCategoryId;
            }

            Helper.DateBase.ConstructionMaterials.Update(constructionMaterial1);
        }
        else
        {
            constructionMaterial1.Article = Article.Text;
            constructionMaterial1.Name = Name.Text;
            constructionMaterial1.UnitOfMeasurement = UnitOfMeasurement.Text;
            constructionMaterial1.Price = Convert.ToInt32(Price.Text);
            constructionMaterial1.MaximumPossibleDiscountSize = Convert.ToInt32(MaximumPossibleDiscountSize.Text);
            constructionMaterial1.CurrentDiscount = Convert.ToInt32(CurrentDiscount.Text);
            constructionMaterial1.Count = Convert.ToInt32(Count.Text);
            constructionMaterial1.Mmanufacturer = ComboBox_Mmanufacturer.SelectedIndex;
            constructionMaterial1.Supplier = ComboBox_Supplier.SelectedIndex;
            constructionMaterial1.ProductCategoryId = ComboBox_ProductCategoryId.SelectedIndex;

            Helper.DateBase.ConstructionMaterials.Add(constructionMaterial1);
        }

        int ggg = 1;
        foreach (ConstructionMaterial constructionMaterial33 in Helper.DateBase.ConstructionMaterials)
        {
            if (Article.Text == constructionMaterial33.Article)
            {
                ggg = 2;
            }
            else if (Article.Text != constructionMaterial33.Article)
            {
                ggg = 1;
            }

        }

        if (ggg == 1)
        {
            if (constructionMaterial1.Price >= 0 && constructionMaterial1.Count >= 0)
            {
                Helper.DateBase.SaveChanges();
                GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user1);
                glavnoeOkko.Show();
                Close();
            }
            else
            {
                Errors3 errors = new Errors3();
                errors.ShowDialog(this);
            }
        }
        else if (ggg == 2)
        {
            Errors3 errors = new Errors3();
            errors.ShowDialog(this);
        }


    }
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user1);
        glavnoeOkko.Show();
        Close();

    }
}