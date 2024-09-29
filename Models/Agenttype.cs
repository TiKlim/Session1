using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class Agenttype
{
    public int Id { get; set; }

    public string? Nametype { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
