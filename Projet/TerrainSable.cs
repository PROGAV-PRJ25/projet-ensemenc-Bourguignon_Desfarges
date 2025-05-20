public class TerrainSable : Terrain
{
    public TerrainSable(double humiditeSol, double qualiteSol, double ensoleillement, double temperature)
        : base("Sable", humiditeSol, qualiteSol, ensoleillement, temperature)
    {
    }

    public TerrainSable(double ensoleillement, double temperature)
        : base("Sable", 10, 5, ensoleillement, temperature)
    {
    }

    public override void PerteHumiditeTour() // Le sable pert énormément d'humidité
    {
        double changement;
        if (HumiditeSol > 50) // gestion des 2 cas extremes
        {
            changement = HumiditeSol * 50 / 100;
            HumiditeSol -= changement;
        }
        else
        {
            changement = HumiditeSol * 30 / 100;
            if ((HumiditeSol - changement) > 0)
            {
                HumiditeSol -= changement;
            }
            else
            {
                HumiditeSol = 0;
            }
        }
    }
}