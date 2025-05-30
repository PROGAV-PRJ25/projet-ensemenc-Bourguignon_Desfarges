public abstract class Terrain
{
    Random rnd = new Random();
    public string TypeSol { get; set; } //ajout d'un type de terrain, sable, argile, terre
    public double HumiditeSol { get; set; } // % niveau d'humidité du sol 
    protected double QualiteSol { get; set; } // richesse du sol en pourcentage 100% sol parfait 0% sol excessivement pauvre
    protected double? Ensoleillement { get; set; } // A VOIR pourcentage d'ensoleillement du soleil
    public double? Temperature { get; set; } // A VOIR Temp en ° qui va être modifié selon la météo
    public Meteo MeteoTerrain { get; set; }
    public Terrain(string typeSol, double humiditeSol, double qualiteSol, Meteo meteo)
    {
        MeteoTerrain = meteo;
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        Ensoleillement = meteo.Ensoleillement;
        Temperature = meteo.Temperature;
        PreparerNouveauTerrain(); // Différenciation à la création de chaque nouveau terrain
    }

    public Terrain(string typeSol, double humiditeSol, double qualiteSol) // Constructeur TEMPORAIRE
    {
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        MeteoTerrain = new MeteoNationTerre();
        PreparerNouveauTerrain(); // Différenciation à la création de chaque nouveau terrain
    }

    public virtual void PreparerNouveauTerrain() // randomise légèrement le terrain
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
    public void AppliquerMeteoTerrain() // changement lié à la météo
    {
        if (MeteoTerrain.IlPleut)
        {
            double changement = 30; // perte d'eau supplémentaire due au soleil
            if ((HumiditeSol + changement) > 0)
            {
                HumiditeSol = 100;
            }
            else
            {
                HumiditeSol = HumiditeSol + changement;
            }
        }
        if (MeteoTerrain.RayonDeSoleil)
        {
            double changement = HumiditeSol * rnd.Next(11)* (-1) / 100; // perte d'eau supplémentaire due au soleil
            while ((HumiditeSol + changement) < 0)
            {
                changement = HumiditeSol * rnd.Next(11) * (-1) / 100;
            }
        }
    }

    public void JouerUnTour()
    {
        AppliquerMeteoTerrain(); // Changement de l'humidité en fonction de la météo
        
        PerteHumiditeTour(); // Perte d'humidité en fonction du terrain

        //PerteDuePlanteTour(); //rajouter perte du plante
    }
}