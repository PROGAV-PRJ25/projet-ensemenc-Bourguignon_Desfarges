public class PlanteComestible : Plante
{
    public PlanteComestible(string nom, string nature, Terrain terrainPrefere, string saisonSemis,
        double besoinsEau, double besoinsLumiere, double temperaturePref, int espacement, int vitesseCroissance,
        Maladies maladies, int esperanceVie, int etatSante, int nbRecoltesMax, string typePlantes)
        : base(nom, nature, terrainPrefere, saisonSemis, besoinsEau, besoinsLumiere, temperaturePref, espacement,
               vitesseCroissance, maladies, esperanceVie, etatSante, nbRecoltesMax, "Comestible")
    {
    }

    public override void Recolter()
    {
        if (EtatSante > 5 && NbRecoltesMax > 0)
        {
            Console.WriteLine($"Récolte des {Nom}. Vous avez récolté des produits comestibles !");
            NbRecoltesMax--; // Réduire le nombre de récoltes possibles
        }
        else if (EtatSante <= 0)
        {
            Console.WriteLine($"{Nom} est trop malade pour récolter.");
        }
        else
        {
            Console.WriteLine($"{Nom} n'a plus de récoltes possibles.");
        }
    }
    public override void Arroser()
    {
        base.Arroser();
        if (BesoinsEau > 75)
        {
            EtatSante = Math.Min(EtatSante + 1, 10);
            Console.WriteLine($"La plante {Nom} comestible se porte mieux après l'arrosage.");
        }
    }
}