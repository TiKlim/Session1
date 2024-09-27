using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class AttachedFile
{
    public int Id { get; set; }

    public int? IdFiles { get; set; }

    public int? IdClients { get; set; }

    public virtual Client? IdClientsNavigation { get; set; }

    public virtual File? IdFilesNavigation { get; set; }
}
