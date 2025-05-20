public abstract class Terrain
{
    Random rnd = new Random();
    protected string TypeSol { get; set; } //ajout d'un type de terrain, sable, argile, terre
    protected double HumiditeSol { get; set; } // % niveau d'humidité du sol 
    protected double QualiteSol { get; set; } // richesse du sol en pourcentage 100% sol parfait 0% sol excessivement pauvre
    protected double Ensoleillement { get; set; } // pourcentage d'ensoleillement du soleil
    public double Temperature { get; set; } // Temp en ° qui va être modifié selon la météo

    public Terrain(string typeSol, double humiditeSol, double qualiteSol, double ensoleillement, double temperature)
    {
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        Ensoleillement = ensoleillement;
        Temperature = temperature;
    }

    public void PreparerNouveauTerrain() // randomise légèrement le terrain; particulièrement utile lors de la création d'un nouveau terrain
    {
        
    }
}