using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using TheSchoolsClients.Models;

namespace TheSchoolsClients;

public partial class ClientsWindow : Window
{
    private Client Client { get; set; }
    // Конструктор класса с инициализацией объектов для добавления клиента.
    public ClientsWindow()
    {
        InitializeComponent();
        Client = new Client();
        BirthCalendar.SelectedDate = DateTime.Now;
        Grid.DataContext = Client;
        PhotoAdd.Click += PhotoAdd_Click;
        Save.Click += Save_Click;
        Idd.Text = string.Empty;
    }
    // Метод для кнопки сохранения.
    private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Если идентификатор клиента равен нулю,
        if (Client.Id == 0)
        {
            Client.DateOfBirth = DateOnly.FromDateTime(BirthCalendar.SelectedDate!.Value);
            Client.DateOfRegistration = DateTime.Now;
            Helper.DataBase.Clients.Add(Client!);
            Helper.DataBase.SaveChanges();
        }
        // В обратном случае.
        else
        {
            Client.DateOfBirth = DateOnly.FromDateTime(BirthCalendar.SelectedDate!.Value);
            Helper.DataBase.Clients.Update(Client!);
            Helper.DataBase.SaveChanges();
        }
        ClientsMain clientsMain = new ClientsMain();
        clientsMain.Show();
        Close();
    }
    // Конструктор класса с инициализацией объектов для редактирования клиента.
    public ClientsWindow(Client client)
    {
        InitializeComponent();
        Client = client;
        BirthCalendar.SelectedDate = DateTime.Parse(Client.DateOfBirth.ToString()!);
        Grid.DataContext = Client;
        PhotoAdd.Click += PhotoAdd_Click;
        Save.Click += Save_Click;
    }
    // Метод для добавления фото клиента
    private async void PhotoAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            AllowMultiple = false, // Пользователь может выбрать только один файл.
            Filters = new List<FileDialogFilter>
            {
                new FileDialogFilter { Name = "Image files", Extensions = new List<string> {"jpg"} } // Фильтр, чтобы отображать файлы только в одном формате (конкретно нам нужен .jpg).
            }
        };
        // Объявляем переменную для хранения пути к файлам.
        var result = await openFileDialog.ShowAsync(this);

        if (result?.Length > 0)
        {
            var filePath = result[0]; // Берём путь к выбранному файлу;
            var appDir = AppContext.BaseDirectory; // Берём базовый католог приложения;
            var fileName = Path.GetFileName(filePath); // Берём имя файла;
            var destinationPath = Path.Combine(appDir, "Assets", fileName); // Создаём путь к файлу;
            Client.Image = fileName; // Присваеваем имя файла к свойству Image;
            ImageC.Source = new Bitmap(destinationPath); // И, наконец, создаём новый объект Bitmap.
        }
    }
}