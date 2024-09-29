using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class Priority
{
    public int Id { get; set; }

    public int? Numberprioritet { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
