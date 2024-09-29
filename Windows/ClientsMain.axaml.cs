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
using TheSchoolsClients.Models;

namespace TheSchoolsClients;

public partial class ClientsMain : Window
{
    public List<Client> ClientsList;
    private List<Client> clients = Helper.DataBase.Clients.ToList();
    public List<Client> FullList = Helper.DataBase.Clients.Include(x => x.VisitingLists).Include(x => x.TagLists).ToList();
    private int PagesElements = Helper.DataBase.Clients.Count();
    private int Page;
    private int AllPages => (FullList.Count + (Page - 1)) / Page;
    public ClientsMain()
    {
        InitializeComponent();
        genderChoise.SelectionChanged += GenderChoise_SelectionChanged;
        LastNameSort.SelectionChanged += LastNameSort_SelectionChanged;
        Search.TextChanged += Search_TextChanged;
        LastDateSort.SelectionChanged += LastDateSort_SelectionChanged;
        CountVisitSort.SelectionChanged += CountVisitSort_SelectionChanged;
        //Remove.Click += Remove_Click;
        //Edit.Click += Edit_Click;
        //History.Click += History_Click;
        
        Backward.Click += Backward_Click;
        Forward.Click += Forward_Click;
        AddClient.Click += AddClient_Click;
        Page = 1;
        SetData();
    }

    private void AddClient_Click(object? sender, RoutedEventArgs e)
    {
        ClientsWindow clientsWindow = new ClientsWindow();
        clientsWindow.Show();
        Close();
    } 

    private void Forward_Click(object? sender, RoutedEventArgs e)
    {
        if (Page < AllPages)
        {
            Page++;
        }

        SetData();
    } 

    private void Backward_Click(object? sender, RoutedEventArgs e)
    {
        if (Page > 1)
        {
            Page--;
        }

        SetData();
    }

    private void History_Click(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    } 

    private void Edit_Click(object? sender, RoutedEventArgs e)
    {
        var id = (int)(sender as Button)?.Tag!;
        var client = Helper.DataBase.Clients.Find(id);

        ClientsWindow clientsWindow = new ClientsWindow(client!);
        clientsWindow.Show();
        Close();
    } 

    private void Remove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int id = (int)(sender as Button)?.Tag!;
        var client = Helper.DataBase.Clients.Find(id);
        if (client != null)
        {
            Helper.DataBase.Clients.Remove(client);
            Helper.DataBase.SaveChanges();
        }
        FullList = Helper.DataBase.Clients.Include(x => x.VisitingLists).Include(x => x.TagLists).ToList();
        SetData();
    }

    private void CountVisitSort_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (CountVisitSort == null) return;
        var sortList = Helper.DataBase.Clients.ToList();
        switch (CountVisitSort.SelectedIndex)
        {
            case 0:
                FullList = sortList;
                break;
            case 1:
                FullList = sortList.OrderByDescending(x => x.CountOfVisits).ToList();
                break;
        }
        SetData();
    }

    private void LastDateSort_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (LastDateSort == null) return;
        var sortList = Helper.DataBase.Clients.ToList();
        switch (LastDateSort.SelectedIndex)
        {
            case 0:
                FullList = sortList;
                break;
            case 1:
                FullList = sortList.OrderByDescending(x => x.LastVisit).ToList();
                break;
        }
        SetData();
    }

    private void Search_TextChanged(object? sender, TextChangedEventArgs e) => SetData();

    private void LastNameSort_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (LastNameSort == null) return;
        var sortList = Helper.DataBase.Clients.ToList();
        switch (LastNameSort.SelectedIndex)
        {
            case 0:
                FullList = sortList;
                break;
            case 1:
                FullList = sortList.OrderBy(x => x.LastName).ToList();
                break;
        }
        SetData();
    }

    private void GenderChoise_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (genderChoise == null) return;
        var sortList = Helper.DataBase.Clients.ToList();
        switch (genderChoise.SelectedIndex)
        {
            case 0:
                FullList = sortList; 
                break;
            case 1:
                FullList = sortList.Where(x => x.Gender == 1).ToList(); 
                break;
            case 2:
                FullList = sortList.Where(x => x.Gender == 2).ToList(); 
                break;
        }
        SetData();
    }

    private void SetData()
    {
        //ClientsLB.ItemsSource = Helper.DataBase.Clients.OrderBy(x => x.Id);
        ClientsLB.ItemsSource = FullList.ToList();
        ClientsList = Helper.DataBase.Clients.Include(x => x.VisitingLists).ToList();
        var sortList = Helper.DataBase.Clients.ToList();

        string SearchSearch = Search.Text ?? "";
        if (SearchSearch.Length > 0)
        {
            FullList = FullList.Where(x => x.Phone.ToLower().Contains(SearchSearch) ||
            x.LastName.ToLower().Contains(SearchSearch) ||
            x.FirstName.ToLower().Contains(SearchSearch) ||
            x.MiddleName.ToLower().Contains(SearchSearch) ||
            x.Email.ToLower().Contains(SearchSearch) ||
            string.IsNullOrEmpty(SearchSearch)).ToList();
        }

        Output.Text = $"{FullList.Count}";
        Total.Text = $"{Helper.DataBase.Clients.Count()}";
    }

    private void Choise(List<Client> sortList)
    {
        PagesElements = QuantityOfElements.SelectedIndex switch
        {
            0 => sortList.Count,
            1 => 10,
            2 => 50,
            3 => 200,
            _ => 200
        };


        foreach (var item in sortList.Skip((Page - 1) * PagesElements).Take(PagesElements))
        {
            ClientsList.Add(item);
        }

        ClientsLB.ItemsSource = ClientsList;
        Output.Text = $"{FullList.Count}";
        Total.Text = $"{Helper.DataBase.Clients.Count()}";
    }
}