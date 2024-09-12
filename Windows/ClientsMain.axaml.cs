using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Castle.Core.Smtp;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using TheSchoolsClients.Context;
using TheSchoolsClients.DataSource;
using TheSchoolsClients.Models;

namespace TheSchoolsClients;

public partial class ClientsMain : Window
{
    public List<Client> ClientsList;
    private int PagesElements = DataSource.Helper.DataBase.Clients.Count();
    private int Page;
    private int AllPages => (ClientsList.Count + (Page - 1)) / Page;
    public ClientsMain()
    {
        InitializeComponent();
        Page = 1;
        SetData();
        Output.Text = $"{ClientsLB.ItemCount}";
        Total.Text = $"{DataSource.Helper.DataBase.Clients.Count()}";
    }

    private void SetData()
    {
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients.OrderBy(x => x.Id);
        ClientsList = DataSource.Helper.DataBase.Clients.Include(x => x.VisitingLists).ToList();
    }

    /*private void Backward(object? sender, RoutedEventArgs e)
    {

    }

    private void Forward(object? sender, RoutedEventArgs e)
    {

    }*/

    private void Choise(List<Client> choiseList)
    {
        PagesElements = QuantityOfElements.SelectedIndex;
        switch (PagesElements)
        {
            case 0:
                PagesElements = choiseList.Count();
                break;
            case 1:
                PagesElements = 10;
                break;
            case 2:
                PagesElements = 50;
                break;
            case 3:
                PagesElements = 200;
                break;
        }

        foreach (var item in choiseList.Skip((Page - 1) * PagesElements).Take(PagesElements))
        {
            ClientsList.Add(item);
        } 
    }
}