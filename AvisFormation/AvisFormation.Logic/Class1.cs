using AvisFormation.Data.Data;

namespace AvisFormation.Logic;

public class Class1
{

    public void GetFormations()
    {

        // after using it's will close database
        using (var context = new AvisFormationdbContext())
        {
            // get all formations in databases
            var listFormations = context.Formations.ToList();
        }
    }

    public void InsertFormation()
    {
        var newFromation = new Formation();
        newFromation.Nom = "testfromation";
        newFromation.Description = "nouveau insertion de formation";

        using ( var context = new AvisFormationdbContext())
        {
            context.Formations.Add(newFromation);
            //must to save the recorhd in database
            context.SaveChanges();
        }
    }

    public void UpdateFormation()
    {
        using (var context = new AvisFormationdbContext())
        {
            var findFromation = context.Formations.FirstOrDefault(formation => formation.NomSeo == "asp-net-mvc");
            if (findFromation != null)
            {
                findFromation.NomSeo = "framework .NET MVC";
            }
            context.SaveChanges();
        }
    }
}

