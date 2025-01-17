using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// <summary>
    /// ������� �� ������ �������� ������
    /// </summary>
    /// <param name="user">����� ����������� �� �������� ����</param>
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
    /// <summary>
    /// ������� �� ������ �������������� ������
    /// </summary>
    /// <param name="user">����� ����������� �� �������� ����</param>
    /// <param name="constructionMaterial">����� ��������� ��������</param>
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
            // ���������� Id
            ID.IsVisible = true;
            TextId.IsVisible = true;
        }
        else
        {
            manufacture = Helper.DateBase.Manufacturers.ToList();
            manufacture.Add(new Manufacturer() { Name = "�������������" });
            ComboBox_Mmanufacturer.ItemsSource = manufacture.OrderByDescending(s => s.Name == "�������������");
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
            supplier.Add(new Supplier() { Name = "����������" });
            ComboBox_Supplier.ItemsSource = supplier.OrderByDescending(s => s.Name == "����������");
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
            productCategory.Add(new ProductCategory() { Name = "���������" });
            ComboBox_ProductCategoryId.ItemsSource = productCategory.OrderByDescending(s => s.Name == "���������");
            ComboBox_ProductCategoryId.SelectedIndex = 0;
        }
    }
    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool upd = false;
        // ���������� ������ ��������
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

            upd = true;
            Helper.DateBase.ConstructionMaterials.Update(constructionMaterial1);
        }
        // �������� ��������
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
            constructionMaterial1.Picture = Convert.ToString(Picture.Source);
            
            Helper.DateBase.ConstructionMaterials.Add(constructionMaterial1);
        }

        // �������� �� ������� �������� � ���� ������ 
        bool ProverkaOnArticle = true;
        foreach (ConstructionMaterial constructionMaterial33 in Helper.DateBase.ConstructionMaterials)
        {
            if (Article.Text == constructionMaterial33.Article)
            {
                ProverkaOnArticle = false;// ���� ������� ������������ � ���� ������ false
                break;
            }
        }

        // ���� ������� �� ������������ � ���� �� ��������
        if (ProverkaOnArticle == true || upd == true)
        {
            // ���� ������������ ��������, �� �������� ������
            if (constructionMaterial1.Name != null)
            {
                // ���� �������� ��. ���. ������, �� �������� ������
                if (constructionMaterial1.UnitOfMeasurement != null)
                {
                    if (constructionMaterial1.UnitOfMeasurement == "��.")
                    {
                        // ���� �������� ���� �������, �� �������� ������
                        if (constructionMaterial1.Price != null)
                        {
                            // ���� �������� ���-�� ��������, �� �������� ������
                            if (constructionMaterial1.Count != null)
                            {
                                // ���� �������� ���� � ���������� ������ 0 � �� ����� �������������� ��������, �� �������� ������
                                if (constructionMaterial1.Price >= 0 && constructionMaterial1.Count >= 0)
                                {
                                    // ���� �������� ������������ ������ ������, �� �������� ������
                                    if (constructionMaterial1.MaximumPossibleDiscountSize != null)
                                    {
                                        // ���� �������� ������ ������, �� �������� ������
                                        if (constructionMaterial1.CurrentDiscount != null)
                                        {
                                            // ���� �������� ������������� ������, �� �������� ������
                                            if (constructionMaterial1.Mmanufacturer != 0)
                                            {
                                                // ���� �������� ���������� ������, �� �������� ������
                                                if (constructionMaterial1.Supplier != 0)
                                                {
                                                    // ���� �������� ��������� ������, �� �������� ������
                                                    if (constructionMaterial1.ProductCategoryId != 0)
                                                    {
                                                        if (constructionMaterial1.MaximumPossibleDiscountSize > 0 && constructionMaterial1.CurrentDiscount > 0)
                                                        {
                                                            Helper.DateBase.SaveChanges();
                                                            GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user1);
                                                            glavnoeOkko.Show();
                                                            Close();
                                                        }
                                                        else
                                                        {
                                                            string warning = "������! ������ �� ����� ���� ��������������!";
                                                            Errors errors = new Errors(warning);
                                                            errors.ShowDialog(this);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string warning = "������! �� �� ������� ���������!";
                                                        Errors errors = new Errors(warning);
                                                        errors.ShowDialog(this);
                                                    }
                                                }
                                                else
                                                {
                                                    string warning = "������! �� �� ������� ����������!";
                                                    Errors errors = new Errors(warning);
                                                    errors.ShowDialog(this);
                                                }
                                            }
                                            else
                                            {
                                                string warning = "������! �� �� ������� �������������!";
                                                Errors errors = new Errors(warning);
                                                errors.ShowDialog(this);
                                            }
                                        }
                                        else
                                        {
                                            string warning = "������! �� �� ������� ����������� ������!";
                                            Errors errors = new Errors(warning);
                                            errors.ShowDialog(this);
                                        }
                                    }
                                    else
                                    {
                                        string warning = "������! �� �� ������� ������������ ������!";
                                        Errors errors = new Errors(warning);
                                        errors.ShowDialog(this);
                                    }
                                }
                                else
                                {
                                    string warning = "������! ���� � ���������� �� ����� ���� ��������������!";
                                    Errors errors = new Errors(warning);
                                    errors.ShowDialog(this);
                                }
                            }
                            else
                            {
                                string warning = "������! ������� ����������!";
                                Errors errors = new Errors(warning);
                                errors.ShowDialog(this);
                            }
                        }
                        else
                        {
                            string warning = "������! ������� ����!";
                            Errors errors = new Errors(warning);
                            errors.ShowDialog(this);
                        }
                    }
                    else
                    {
                        string warning = "������! �������� ������ ��. ���������! ������� � (��.)!";
                        Errors errors = new Errors(warning);
                        errors.ShowDialog(this);
                    }
                }
                else
                {
                    string warning = "������! ������� ������� ���������!";
                    Errors errors = new Errors(warning);
                    errors.ShowDialog(this);
                }
            }
            else
            {
                string warning = "������! ������� ������������!";
                Errors errors = new Errors(warning);
                errors.ShowDialog(this);
            }
        }
        else if (ProverkaOnArticle == false)
        {
            string warning = "������! ������� ��� �����!";
            Errors errors = new Errors(warning);
            errors.ShowDialog(this);
        }
    }
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GlavnoeOkko glavnoeOkko = new GlavnoeOkko(user1);
        glavnoeOkko.Show();
        Close();
    }
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new List<string>() { "png", "jpg", "jpeg" }
    };
    private async void Button_Click_Update_Image(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(fileFilter);
            var result = await dialog.ShowAsync(this);
            string file = String.Join("", result);
            long length = new System.IO.FileInfo(file).Length;
            Random random = new Random();
            string photo = "Assets/photo" + random.Next(1, 10808) + ".jpg";
            System.IO.File.Copy(file, photo);
            Picture.Source = new Bitmap(photo);
            constructionMaterial1.Picture = photo.Substring(6);
        }
        catch { }
    }
               
}