using System;
using AvisFormation.Data.Data;

namespace AvisFormationUI.Models
{
	public class FormationAvecAvis
	{
		public FormationAvecAvis()
		{
		}

        public string FormationNom { get; internal set; }
        public string FormationDescription { get; internal set; }
        public string FormationNomSeo { get; internal set; }
        public string? FormationUrl { get; internal set; }
        public double Note { get; internal set; }
        public int NombreAvis { get; internal set; }
        public List<Avi> Avis { get; internal set; }
    }
}

