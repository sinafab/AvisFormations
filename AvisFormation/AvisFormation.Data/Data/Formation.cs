using System;
using System.Collections.Generic;

namespace AvisFormation.Data.Data;

public partial class Formation
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Url { get; set; }

    public string Description { get; set; } = null!;

    public string NomSeo { get; set; } = null!;

    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();
}
