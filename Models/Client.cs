using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSchoolsClients.Models;

public partial class Client
{
    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public int? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Image { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfRegistration { get; set; }

    public int Id { get; set; }

    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();

    public virtual Gender? GenderNavigation { get; set; }

    public virtual ICollection<TagList> TagLists { get; set; } = new List<TagList>();

    public virtual ICollection<VisitingList> VisitingLists { get; set; } = new List<VisitingList>();
    public DateOnly? LastVisit => VisitingLists.Count != 0 ? VisitingLists.Select(x => x.Date).Order().First() : null!;

    public string gender => Gender == 1 ? "мужчина" : "женщина";

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public Bitmap? Picture => Image != null ? new Bitmap($@"Assets\\{Image}") : null;

    public int? CountOfVisits => VisitingLists.Count();
}
