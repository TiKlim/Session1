using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class Agent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Countofrealizationyear { get; set; }

    public int? Sale { get; set; }

    public string? Phone { get; set; }

    public int? Typeofagent { get; set; }

    public string? Email { get; set; }

    public int? Prioritet { get; set; }

    public string? Adress { get; set; }

    public string? Inn { get; set; }

    public int? Kpp { get; set; }

    public string? Directorname { get; set; }

    public virtual Priority? PrioritetNavigation { get; set; }

    public virtual Agenttype? TypeofagentNavigation { get; set; }
}
