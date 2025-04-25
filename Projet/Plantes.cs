public abstract class Plante
{
    public string Nom { get; set; }
    public string Nature { get; set; }
    public Terrain TerrainPrefere { get; set; }
    public string SaisonSemis { get; set; }
    public double BesoinsEau { get; set; }
    public double BesoinsLumiere { get; set; }
    public double TemperaturePref { get; set; }
    public int VitesseCroissance { get; set; }
    public Maladies Maladies { get; set; }
    public int EsperanceVie { get; set; }
    public int EtatSante { get; set; }
    public int NbRecoltesMax { get; set; }
    public string TypePlantes { get; set; }

    public Plante(string Nom, string Nature, Terrain TerrainPrefere, string SaisonSemis, double BesoinsEau,
                  double BesoinsLumiere, double TemperaturePref, int VitesseCroissance,
                  Maladies Maladies, int EsperanceVie, int EtatSante, int NbRecoltesMax, string TypePlantes)
    {
        this.Nom = Nom;
        this.Nature = Nature;
        this.TerrainPrefere = TerrainPrefere;
        this.SaisonSemis = SaisonSemis;
        this.BesoinsEau = BesoinsEau;
        this.BesoinsLumiere = BesoinsLumiere;
        this.TemperaturePref = TemperaturePref;
        this.VitesseCroissance = VitesseCroissance;
        this.Maladies = Maladies;
        this.EsperanceVie = EsperanceVie;
        this.EtatSante = EtatSante;
        this.NbRecoltesMax = NbRecoltesMax;
        this.TypePlantes = TypePlantes;
    }

    public abstract void Recolter();
    public void AppliquerConditionsMeteo(Meteo meteo)
    {
        // Si les conditions météo sont mauvaises pour la plante (température, humidité, gel, etc.)
        if (Math.Abs(meteo.Temperature - TemperaturePref) > 5 || meteo.Gel)
        {
            EtatSante -= 2; // Réduction de l'état de santé de la plante
        }

        if (meteo.Precipitations > 30 && BesoinsEau < 50)
        {
            EtatSante -= 1; // Trop d'eau peut affecter la santé
        }

        if (meteo.Precipitations < 10 && BesoinsEau > 50)
        {
            EtatSante -= 1; // Pas assez d'eau peut affecter la santé
        }
    }
    public virtual void Arroser()
    {
        if (BesoinsEau > 50)
        {
            EtatSante = Math.Min(EtatSante + 1, 10);
            Console.WriteLine($"{Nom} a été arrosée et son état de santé est maintenant {EtatSante}/10.");
        }
        else
        {
            Console.WriteLine($"{Nom} n'a pas besoin d'arrosage supplémentaire.");
        }
    }
}
