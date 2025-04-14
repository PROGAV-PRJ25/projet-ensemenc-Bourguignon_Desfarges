public abstract class Plante {
    
    public string Nom {get; set;}

    public string Nature {get; set;} // Nature de la plante (annuelle ou vivace)

    public Terrain TerrainPrefere {get; set;} 

    public string SaisonSemis {get; set;} 

    public double BesoinsEau {get; set;}

    public double BesoinsLumiere { get; set;}

    public double TemperaturePref {get; set;}

    public int  Espacement {get; set;} // Nombre de case autour de la plante qui ne devront pas être occupées

    public int VitesseCroissance {get; set;} // Temps pour que la plante pouuse, donne des ressources, ...

    public Maladies Maladies {get; set;} // Classe Maladies avec les différentes types et une probabilité  

    public int EsperanceVie {get; set;}

    public int EtatSante {get; set;} // Sur une échelle de 0 à 10 où 0 correspond à la mort et 10 en parfaite santé

    public int NbRecoltesMax {get; set;} // Nombre maximum qu'une plante peut produire

    public string TypePlantes {get; set;} //Comestible, Colectible, décorative,...


    public Plante (string Nom, string Nature, Terrain TerrainPrefere, string SaisonSemis, double BesoinsEau, double BesoinsLumiere, double TemperaturePref, int Espacement, int VitesseCroissance, Maladies Maladies, int EsperanceVie, int EtatSante, int NbRecoltesMax)
    {
        this.Nom = Nom;
        this.Nature = Nature;
        this.TerrainPrefere=TerrainPrefere;
        this.SaisonSemis=SaisonSemis;
        this.BesoinsEau = BesoinsEau;
        this.BesoinsLumiere=BesoinsLumiere;
        this.TemperaturePref=TemperaturePref;
        this.Espacement=Espacement;
        this.VitesseCroissance=VitesseCroissance;
        this.Maladies=Maladies;
        this.EsperanceVie=EsperanceVie;
        this.EtatSante=EtatSante;
        this.NbRecoltesMax=NbRecoltesMax;
        this.TypePlantes=TypePlantes;
}
}