public abstract class Plante
{
    public string Nom { get; set; }
    public Terrain? TerrainPlante { get; set; }
    public int VitesseCroissance { get; set; } // nombre de Tour pour atteindre l'age de maturité    
    public int EsperanceVie { get; set; } // nombre de tour avant de mourir
    public int EtatSante { get; set; } // etat de sante de la plante sur 5 si 0 elle meurt
    public int NombreFruit { get; set; } // nombre de fruit/recolte par tour que la plante donne lorsqu'elle est mure
    public int Age { get; set; }
    public double[] HumiditeLim { get; set; } 
    public double[] ChaleurLim { get; set; } 

    public bool Dessechee { get; set; }
    public bool BonneTemp { get; set; }
    public bool Morte { get; set; }

    public Plante(string nom, int vitesseCroissance, int esperanceVie, int nombreFruit, double[] humMin, double[] chaleurlim)
    {
        Nom = nom;
        VitesseCroissance = vitesseCroissance;
        EsperanceVie = esperanceVie;
        EtatSante = 5;
        NombreFruit = nombreFruit;
        Age = 0;
        Dessechee = TestEau();
        BonneTemp = TestTemp();
        Morte = false;
        HumiditeLim = humMin;
        ChaleurLim = chaleurlim;
    }

    public void MourirPlante()
    {
        if (Dessechee && !BonneTemp) // si 50% des conditions de survie de la plante ne sont pas réunie elle meurt
        {
            Morte = true;
        }
        if (Age > EsperanceVie)
        {
            Morte = true;
        }
        if (EtatSante <= 0)
        {
            Morte = true;
        }
    }


    public bool TestEau()
    {
        if (TerrainPlante != null && (TerrainPlante.HumiditeSol < HumiditeLim[0] || TerrainPlante.HumiditeSol > HumiditeLim[1]))
        {
            EtatSante = EtatSante - 2;
            return false;
        }
        else
        {
            EtatSante++;
            return true;
        }
    }

    public bool TestTemp()
    {
        if (TerrainPlante != null && (TerrainPlante.Temperature < ChaleurLim[0] || TerrainPlante.Temperature > ChaleurLim[1]))
        {
            EtatSante -= 2;
            return false;            
        }
        else
        {
            EtatSante += 1;
            return true;
        }
    }


    public void TourPlante()
    {
        Age++;
        TestEau();
        TestTemp();
        MourirPlante();
    }

    public abstract string GetIcone();
}