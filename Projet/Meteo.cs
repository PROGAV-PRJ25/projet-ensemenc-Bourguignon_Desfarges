public class Meteo
{
    public double Temperature { get; set; }
    public double Precipitations { get; set; }
    public bool Gel { get; set; }

    public Meteo(double temperature, double precipitations, bool gel)
    {
        Temperature = temperature;
        Precipitations = precipitations;
        Gel = gel;
    }

    public void AppliquerMeteo(Plante plante)
    {
        if (Gel && plante.TemperaturePref < 0)
        {
            plante.EtatSante = 0; // La plante meurt si la température descend trop bas
        }
        else
        {
            plante.EtatSante -= (int)(Math.Abs(plante.TemperaturePref - Temperature) / 10);
            if (Precipitations > 20) plante.EtatSante -= 1; // Trop d'eau peut nuire
        }
    }
}