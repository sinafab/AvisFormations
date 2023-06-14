using System;
using System.Collections.Generic;

namespace AvisFormation.Data.Data;

public partial class Avi
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Description { get; set; }

    public float Note { get; set; }

    public DateTime DateAvis { get; set; }

    public string UserId { get; set; } = null!;

    public int IdFormation { get; set; }

    public virtual Formation IdFormationNavigation { get; set; } = null!;
}
