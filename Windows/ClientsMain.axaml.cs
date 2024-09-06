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
        ClientsLB.ItemsSource = DataSource.Helper.DataBase.Clients.Select(x => new
        {
            x.LastName,
            x.FirstName,
            x.MiddleName,
            x.IdGender,
            x.Phone,
            x.Image,
            x.DateOfBirth,
            x.Email,
            x.DateOfRegistration,
            x.Id,
            x.IdTag
        });
    }
}