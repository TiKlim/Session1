using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Metsys.Bson;
using System.Linq;
using System.Numerics;
using TheSchoolsClients.DataSource;

namespace TheSchoolsClients;

public partial class ClientsMain : Window
{
    public ClientsMain()
    {
        InitializeComponent();
        SetData();
        Output.Text = $"{ClientsLB.ItemCount}";
        Total.Text = $"{DataSource.Helper.DataBase.Clients.Count()}";
    }

    private void SetData()
    {
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients;
    }
}