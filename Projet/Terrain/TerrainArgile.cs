public class TerrainArgile : Terrain
{
    Random rnd = new Random();
    // un terrain argileux est un terrain riche en eau, son taux d'humidité est  de 50%
    // un terrain argileux est riche en minéraux
    public TerrainArgile(Meteo m)
        : base("Argile", 50, 80, m)
    {
    }

    public TerrainArgile() : base("Argile", 50, 80)
    {
    }


    public override void PerteHumiditeTour() // L'argile pert très peu d'humidité
    {
        double changement;
        changement = HumiditeSol * 2 / 100;
        if ((HumiditeSol - changement) > 0)
        {
            HumiditeSol -= changement;
        }
        else
        {
            HumiditeSol = 0;
        }
    }



    public override void PerteDuePlanteTour()
    {
        throw new NotImplementedException();
    }
}
