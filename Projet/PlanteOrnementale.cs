public class PlanteOrnementale : Plante
{
    public PlanteOrnementale(string nom, string nature, Terrain terrainPrefere, string saisonSemis,
        double besoinsEau, double besoinsLumiere, double temperaturePref, int espacement, int vitesseCroissance,
        Maladies maladies, int esperanceVie, int etatSante, int nbRecoltesMax, string typePlantes)
        : base(nom, nature, terrainPrefere, saisonSemis, besoinsEau, besoinsLumiere, temperaturePref, espacement,
               vitesseCroissance, maladies, esperanceVie, etatSante, nbRecoltesMax, "Ornemental")
    {
    }

    public override void Recolter()
    {
        if (EtatSante > 5)
        {
            Console.WriteLine($"Coupe de {Nom} pour embellir votre jardin !");
        }
        else if (EtatSante <= 0)
        {
            Console.WriteLine($"{Nom} est trop malade pour être coupée.");
        }
        else
        {
            Console.WriteLine($"{Nom} n'est pas assez en bonne santé pour être récoltée.");
        }
    }
    public override void Arroser()
    {
        base.Arroser();
        if (BesoinsEau > 60)
        {
            EtatSante = Math.Min(EtatSante + 1, 10);
            Console.WriteLine($"La plante {Nom} comestible se porte mieux après l'arrosage.");
        }
    }
}