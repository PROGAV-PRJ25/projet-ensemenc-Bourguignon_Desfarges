public abstract class Plante
{
    public string Nom { get; set; }
    //public string Nature { get; set; }
    //public Terrain TerrainActuel { get; set; }
    //public string SaisonSemis { get; set; }
    //public double BesoinsEau { get; set; }
    //public double BesoinsLumiere { get; set; }
    //public double TemperaturePref { get; set; }
    //public int Espacement { get; set; }
    //public int VitesseCroissance { get; set; }
    //public Maladies Maladies { get; set; }
    //public int EsperanceVie { get; set; }
    //public int EtatSante { get; set; }
    //public int NbRecoltesMax { get; set; }
    //public string TypePlantes { get; set; }
    //public int Age { get; private set; } = 0;
    //public double EauActuelle { get; private set; } = 0;

    public Plante(string nom)
    {
        Nom = nom;
    }
 
    




    // public void Arroser()
    // {
    //     EauActuelle += 10;
    //     Console.WriteLine($"{Nom} a été arrosée (+10). Eau actuelle : {EauActuelle}/{BesoinsEau}.");
    // }

    // public virtual void Recolter()
    // {
    //     if (NbRecoltesMax > 0)
    //     {
    //         NbRecoltesMax--;
    //         Console.WriteLine($"{Nom} a été récoltée ! Récoltes restantes : {NbRecoltesMax}");
    //         if (NbRecoltesMax == 0)
    //         {
    //             Console.WriteLine($"{Nom} ne peut plus être récoltée et meurt.");
    //             EtatSante = 0;
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine($"{Nom} ne peut plus être récoltée.");
    //         EtatSante = 0;
    //     }
    // }

    public abstract string GetIcone();
    //protected abstract int GetModificateurTerrain(); // bonus lié au terrain a voir dans chaque class Plante...
}