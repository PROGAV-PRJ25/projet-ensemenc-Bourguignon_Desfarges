public abstract class Meteo
{
    Random rnd = new Random();
    private double temperature;
    public double Temperature // on ne veut pas que la température dépasse certains stades
    {
        get { return temperature; }
        set
        {
            if (value < -20)
            {
                temperature = -20;
            }
            else if (value > 50)
            {
                temperature = 50;
            }
            else
            {
                temperature = value;
            }
        }
    }
    public int Pluie { get; set; } // Probabilités sur 10 pour qu'il pleuve dans la région
    public int Ensoleillement { get; set; } // sur 10
    public int CatastropheNaturel { get; set; } // Probabilités sur 20 pour qu'il y ait une catastrophe naturelle
    public bool IlPleut { get; set; } // Permet de savoir si a un Tour donnée, il pleut
    public bool RayonDeSoleil { get; set; }
    public bool CatastropheEnCours { get; set; }

    public Meteo(double temperature, int pluie, int ensoleillement)
    {
        Temperature = temperature;
        Pluie = pluie;      // on considère qu'il peut y avoir de la pluie et des rayons de Soleil en même temps
        Ensoleillement = ensoleillement;
        CatastropheNaturel = 1;
        RandomiserMeteo();
    }

    public void AppliquerMeteoTour() // appliquer la météo sur un Tour
    {
        RandomiserMeteo();
    }

    public abstract void AppliquerIntemperie();

    public void RandomiserMeteo()
    {
        int test = rnd.Next(10);
        if (test < Pluie)
        {
            IlPleut = true;
        }
        else
        {
            IlPleut = false;
        }
        test = rnd.Next(10);
        if (test < Ensoleillement)
        {
            RayonDeSoleil = true;
        }
        else
        {
            RayonDeSoleil = false;
        }
        test = rnd.Next(20);
        if (test < Ensoleillement)
        {
            CatastropheEnCours = true;
        }
        else
        {
            CatastropheEnCours = false;
        }
        Temperature = Math.Truncate(Temperature + Temperature * rnd.Next(-11, 11));
    }
}