using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSchoolsClients.Context;
using TheSchoolsClients.Models;

namespace TheSchoolsClients;

public class Helper
{
    public static readonly KlimBaseContext DataBase = new KlimBaseContext();
}
