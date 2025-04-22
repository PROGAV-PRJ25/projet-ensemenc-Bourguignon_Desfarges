public abstract class Terrain
{
    public string TypeSol { get; set; } //ajout d'un type de terrain, sable, argile, terre
    public double HumiditeSol { get; set; } // % niveau d'humidité du sol 
    public double QualiteSol { get; set; } // richesse du sol en pourcentage 100% sol parfait 0% sol excessivement pauvre
    public double Ensoleillement { get; set; } // pourcentage d'ensoleillement du soleil
    public double Temperature { get; set; } // Temp en °

    public Terrain(string typeSol, double humiditeSol, double qualiteSol, double ensoleillement, double temperature)
    {
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        QualiteSol = qualiteSol;
        Ensoleillement = ensoleillement;
        Temperature = temperature;
    }
    public bool EstCompatibleAvecPlante(Plante plante)
    {
        return this.TypeSol == plante.TerrainPrefere.TypeSol &&
               Math.Abs(this.HumiditeSol - plante.BesoinsEau) <= 20 &&
               Math.Abs(this.Ensoleillement - plante.BesoinsLumiere) <= 20 &&
               Math.Abs(this.Temperature - plante.TemperaturePref) <= 5;
    }
}