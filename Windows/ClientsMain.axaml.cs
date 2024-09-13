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
    public List<Client> FullList = DataSource.Helper.DataBase.Clients.Include(x => x.VisitingLists).ToList();
    private int PagesElements = DataSource.Helper.DataBase.Clients.Count();
    private int Page;
    private int AllPages => (FullList.Count + (Page - 1)) / Page;
    public ClientsMain()
    {
        InitializeComponent();
        Page = 1;
        SetData();
        Output.Text = $"{PagesElements}";
        Total.Text = $"{DataSource.Helper.DataBase.Clients.Count()}";
    }

    private void SetData()
    {
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients.OrderBy(x => x.Id);
        ClientsList = DataSource.Helper.DataBase.Clients.Include(x => x.VisitingLists).ToList();

        var sortList = FullList.ToList();

        /*sortList = genderChoise.SelectedIndex
            switch
        {
            0 => sortList,
            1 => sortList.Select(x => x.Gender).ToList(),
        };*/

        sortList = LastNameSort.SelectedIndex
            switch
        {
            0 => sortList,
            1 => sortList.OrderBy(x => x.LastName).ToList()
        };


        sortList = LastDateSort.SelectedIndex
            switch
        {
            0 => sortList,
            1 => sortList.OrderByDescending(x => x.LastVisit).ToList()
        };

        sortList = CountVisitSort.SelectedIndex
            switch
        {
            0 => sortList,
            1 => sortList.OrderByDescending(x => x.CountOfVisits).ToList()
        };

    }

    /*private void Backward(object? sender, RoutedEventArgs e)
    {
        if (Page > 1)
        {
            Page--;
        }
        SetData();
    }

    private void Forward(object? sender, RoutedEventArgs e)
    {
        if (Page < AllPages)
        {
            Page++;
        }
        SetData();
    }*/

    private void Choise(List<Client> sortList)
    {
        PagesElements = QuantityOfElements.SelectedIndex;
        switch (PagesElements)
        {
            case 0:
                PagesElements = sortList.Count();
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


        foreach (var item in sortList.Skip((Page - 1) * PagesElements).Take(PagesElements))
        {
            ClientsList.Add(item);
        }

        //Output.Text = $"{PagesElements}";
        //Output.Text = $"{sortList.Count}";
    }
}