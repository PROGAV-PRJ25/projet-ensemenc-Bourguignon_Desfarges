public class TerrainTerre : Terrain
{
    public TerrainTerre(Meteo m)
        : base("Terre", 40, 70, m)
    {
    }
    public TerrainTerre(): base("Terre", 40, 70) // Constructeur TEMPORAIRE
    {
    }

    public override void PerteHumiditeTour()
    {
        double changement;
        if (HumiditeSol > 80) // gestion des 2 cas extremes
        {
            changement = HumiditeSol * 30 / 100;
            HumiditeSol -= changement;
        }
        if (HumiditeSol < 20)
        {
            changement = HumiditeSol * 5 / 100;
            if ((HumiditeSol - changement) > 0)
            {
                HumiditeSol -= changement;
            }
            else
            {
                HumiditeSol = 0;
            }
        }
        else
        {
            changement = HumiditeSol * 10 / 100;
            HumiditeSol -= changement;
        }
    }

    public override void PerteDuePlanteTour() // si il y a une plante sur le terrain, en fonction du type de plante, le sol pert des ressources
    {
        throw new NotImplementedException();
    }

    public override void AppliquerMeteoTerrain()
    {
        throw new NotImplementedException();
    }
}
