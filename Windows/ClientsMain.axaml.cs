using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Metsys.Bson;
using System.Linq;
using TheSchoolsClients.DataSource;

namespace TheSchoolsClients;

public partial class ClientsMain : Window
{
    public ClientsMain()
    {
        InitializeComponent();
        SetData();
    }

    private void SetData()
    {
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients;
    }
}