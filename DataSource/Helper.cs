using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSchoolsClients.Context;
using TheSchoolsClients.Models;

namespace TheSchoolsClients.DataSource;

public class Helper
{
    public static readonly User734Context DataBase = new User734Context();
}
