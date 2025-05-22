public abstract class Meteo
{
    Random rnd = new Random();
    public double Temperature { get; set; }
    public double Pluie { get; set; } // Probabilités sur 10 pour qu'il pleuve dans la région
    public double Ensoleillement { get; set; } // sur 10
    public double CatastropheNaturel { get; set; } // Probabilités sur 10 pour qu'il y ait une catastrophe naturelle


    public Meteo(double temperature, double pluie, double ensoleillement)
    {
        Temperature = temperature;
        Pluie = pluie;
        Ensoleillement = ensoleillement;
        CatastropheNaturel = 10;
    }

    public void AppliquerMeteoTour() // appliquer la météo sur un Tour
    {

    }

    public abstract void AppliquerIntemperie();

    public void CreerMeteo()
    {
        Temperature = Math.Truncate(Temperature + Temperature * rnd.Next(-11, 10));
        Ensoleillement = Math.Truncate(Ensoleillement + Ensoleillement * rnd.Next(-11, 10));
    }
}