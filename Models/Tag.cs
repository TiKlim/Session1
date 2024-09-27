using Avalonia.Media;
using System;
using System.Collections.Generic;

namespace TheSchoolsClients.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? TagName { get; set; } = null!;

    public string? TagColor { get; set; } = null!;
    public SolidColorBrush ColorTag => SolidColorBrush.Parse($"#{TagColor}");

    public virtual ICollection<TagList> TagLists { get; set; } = new List<TagList>();
}
