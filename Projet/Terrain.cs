public abstract class Terrain
{
    Random rnd = new Random();
    protected string TypeSol { get; set; } //ajout d'un type de terrain, sable, argile, terre
    protected double HumiditeSol { get; set; } // % niveau d'humidité du sol 
    protected double QualiteSol { get; set; } // richesse du sol en pourcentage 100% sol parfait 0% sol excessivement pauvre
    protected double? Ensoleillement { get; set; } // A VOIR pourcentage d'ensoleillement du soleil
    public double? Temperature { get; set; } // A VOIR Temp en ° qui va être modifié selon la météo
    public Meteo meteo { get; set; }
    public Terrain(string typeSol, double humiditeSol, double qualiteSol, double ensoleillement, double temperature)
    {
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        Ensoleillement = ensoleillement;
        Temperature = temperature;
        PreparerNouveauTerrain(); // Différenciation à la création de chaque nouveau terrain
    }

    public Terrain(string typeSol, double humiditeSol, double qualiteSol) // Constructeur TEMPORAIRE
    {
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        PreparerNouveauTerrain(); // Différenciation à la création de chaque nouveau terrain
    }

    public void PreparerNouveauTerrain() // randomise légèrement le terrain
    {
        double changement = HumiditeSol * rnd.Next(-11, 11) / 100; // changement de 1 à  10 %
        while ((HumiditeSol + changement) > 100 || (HumiditeSol + changement) < 0) // HumiditeSol doit resté un pourcentage
        {
            changement = HumiditeSol * rnd.Next(-11, 11) / 100;
        }
        changement = QualiteSol * rnd.Next(-11, 11) / 100; // changement de 1 à  10 %
        while ((QualiteSol + changement) > 100 || (QualiteSol + changement) < 0)
        {
            changement = QualiteSol * rnd.Next(-11, 11) / 100;
        }
        changement = QualiteSol * rnd.Next(-11, 11) / 100; // changement de 1 à  10 %
        while ((QualiteSol + changement) > 100 || (QualiteSol + changement) < 0)
        {
            changement = QualiteSol * rnd.Next(-11, 11) / 100;
        }
    }

    public abstract void PerteHumiditeTour(); // a chaque tour, le terrain pert une quantité d'humidité
    public abstract void PerteDuePlanteTour(); // à discuter, mais correspondrait aux minéraux (qualité sol) et a l'au (humidité sol, consommé par la plante)
    public abstract void AppliquerMeteoTerrain(); // changement lié à la météo

    public void JouerUnTour()
    {
        PerteHumiditeTour();
        PerteDuePlanteTour();
    }
}