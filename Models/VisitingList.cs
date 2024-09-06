using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class VisitingList
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
