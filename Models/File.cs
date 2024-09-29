using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class File
{
    public int Id { get; set; }

    public string? File1 { get; set; }

    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();
}
