public abstract class Meteo
{
    Random rnd = new Random();
    private double temperature;
    public double Temperature // on ne veut pas que la température dépasse certains stades
    {
        get { return temperature; }
        set
        {
            if (value < -10)
            {
                temperature = -10;
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
        Console.WriteLine($"\nLa température moyenne de la semaine est de : {Temperature} ");
    }

    public abstract void AppliquerIntemperie();

    public void RandomiserMeteo()
    {
        int test = rnd.Next(10);
        if (test < Pluie)
        {
            IlPleut = true;
            Console.WriteLine("Il pleut cette semaine ! l'humidité du sol a du augmentée ! 💧");
        }
        else
        {
            IlPleut = false;
            Console.WriteLine("Hmmm, il n'a pas plu...");
        }
        test = rnd.Next(10);
        if (test < Ensoleillement)
        {
            RayonDeSoleil = true;
            Console.WriteLine("Il y a aussi eu de grand rayon de soleil ! ☀️");
            Temperature += 2;
        }
        else
        {
            RayonDeSoleil = false;
            Console.WriteLine("Pas un rayon de soleil a l'horizon...");
            Temperature -= 2;
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
        Temperature = Math.Round(Temperature + rnd.NextDouble() * rnd.Next(-3,4),2);
    }
}