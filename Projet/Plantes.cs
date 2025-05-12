public abstract class Plante
{
    public string Nom { get; set; }
    public string Nature { get; set; }
    public Terrain TerrainActuel { get; set; }
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
    public int Age { get; private set; } = 0;
    public double EauActuelle { get; private set; } = 0;

<<<<<<< HEAD
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
=======
    protected Plante(string nom, string nature, Terrain terrainActuel, string saisonSemis,
                      double besoinsEau, double besoinsLumiere, double temperaturePref,
                      int espacement, int vitesseCroissance, Maladies maladies,
                      int esperanceVie, int etatSante, int nbRecoltesMax, string typePlantes)
    {
        Nom = nom;
        Nature = nature;
        TerrainActuel = terrainActuel;
        SaisonSemis = saisonSemis;
        BesoinsEau = besoinsEau;
        BesoinsLumiere = besoinsLumiere;
        TemperaturePref = temperaturePref;
        Espacement = espacement;
        VitesseCroissance = vitesseCroissance;
        Maladies = maladies;
        EsperanceVie = esperanceVie;
        EtatSante = etatSante;
        NbRecoltesMax = nbRecoltesMax;
        TypePlantes = typePlantes;

        // Initialiser l'eau actuelle aux besoins en eau lors de la plantation
        EauActuelle = BesoinsEau;
>>>>>>> main
    }

    public void PasserTour(Meteo meteo)
    {

        // Vieillissement
        Age++;
        if (Age >= EsperanceVie)
        {
            Console.WriteLine($"{Nom} a atteint son espérance de vie et meurt.");
            EtatSante = 0;
            return;
        }

        // Consommation d'eau
        EauActuelle = Math.Max(0, EauActuelle - 5);

        // Ajustement de la santé selon l'eau
        if (EauActuelle >= BesoinsEau)
        {
            EtatSante = Math.Min(10, EtatSante + 1);
        }
        else if (EauActuelle <= BesoinsEau / 10)
        {
            Console.WriteLine($"{Nom} manque gravement d'eau et perd 2 points de santé.");
            EtatSante = Math.Max(0, EtatSante - 2);
        }
        else
        {
            Console.WriteLine($"{Nom} manque d'eau et perd 1 point de santé.");
            EtatSante = Math.Max(0, EtatSante - 1);
        }

        // Conditions météo
        AppliquerConditionsMeteo(meteo);

        // Bonus/Malus terrain
        int bonus = GetModificateurTerrain();
        if (bonus != 0)
        {
            EtatSante = Math.Clamp(EtatSante + bonus, 0, 10);
            string signe = bonus > 0 ? "+" : string.Empty;
            Console.WriteLine($"{Nom} reçoit {signe}{bonus} point(s) de santé grâce au terrain {TerrainActuel.GetType().Name}.");
        }
    }

    public void Arroser()
    {
        EauActuelle += 10;
        Console.WriteLine($"{Nom} a été arrosée (+10). Eau actuelle : {EauActuelle}/{BesoinsEau}.");
    }

    public virtual void Recolter()
    {
        if (NbRecoltesMax > 0)
        {
            NbRecoltesMax--;
            Console.WriteLine($"{Nom} a été récoltée ! Récoltes restantes : {NbRecoltesMax}");
            if (NbRecoltesMax == 0)
            {
                Console.WriteLine($"{Nom} ne peut plus être récoltée et meurt.");
                EtatSante = 0;
            }
        }
        else
        {
            Console.WriteLine($"{Nom} ne peut plus être récoltée.");
            EtatSante = 0;
        }
    }

    public void AppliquerConditionsMeteo(Meteo meteo)
    {
        if (Math.Abs(meteo.Temperature - TemperaturePref) > 5 || meteo.Gel)
            EtatSante = Math.Max(0, EtatSante - 2);
        if (meteo.Precipitations > 30 && BesoinsEau < 50) // peut etre pas besoin de besoinEau ds tt les cas pas bon pour plante
            EtatSante = Math.Max(0, EtatSante - 1);
        if (meteo.Precipitations < 10 && BesoinsEau > 50)
            EtatSante = Math.Max(0, EtatSante - 1);
    }

    protected abstract int GetModificateurTerrain(); // bonus lié au terrain a voir dans chaque class Plante...
}