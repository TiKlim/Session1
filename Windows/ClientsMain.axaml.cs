using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Metsys.Bson;
using System;
using System.Linq;
using System.Numerics;
using TheSchoolsClients.DataSource;

namespace TheSchoolsClients;

public partial class ClientsMain : Window
{
    public ClientsMain()
    {
        InitializeComponent();
        /*int a = Convert.ToInt32(DataSource.Helper.DataBase.Clients.Count());
        if (0 <= a - 1)
        {
            for (int i = 0; i < a; i++)
            {
                DataSource.Helper.DataBase.Clients[i].Id = i;
            }
        }*/
        SetData();
        Output.Text = $"{ClientsLB.ItemCount}";
        Total.Text = $"{DataSource.Helper.DataBase.Clients.Count()}";
    }

    private void SetData()
    {
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients;
    }
}