using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class Client
{
    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public int? IdGender { get; set; }

    public string? Phone { get; set; }

    public string? Image { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfRegistration { get; set; }

    public int Id { get; set; }

    public int? IdTag { get; set; }

    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual ICollection<TagList> TagLists { get; set; } = new List<TagList>();

    public virtual ICollection<VisitingList> VisitingLists { get; set; } = new List<VisitingList>();
}