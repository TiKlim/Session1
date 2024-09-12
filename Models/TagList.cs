using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class TagList
{
    public int Id { get; set; }

    public int? IdTag { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Tag? IdTagNavigation { get; set; }
}
