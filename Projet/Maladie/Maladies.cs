public class Maladies
{
    public string Nom { get; set; } // Nom de la maladie
    public double ProbabiliteContamination { get; set; } // probabilité de contamination de la plante entre 0 et 1
    public string Symptomatologie { get; set; } // Description des différents symptomes
    public Maladies(string nom, double prob, string symptomes)
    {
        Nom = nom;
        ProbabiliteContamination = prob;
        Symptomatologie = symptomes;
    }

    public Maladies(string nom, double prob) // constrcuteur sans description des symptomes
    {
        Nom = nom;
        ProbabiliteContamination = prob;
        Symptomatologie = "Pas d'informations";
    }

    public bool PeutContaminer()
    {
        Random rand = new Random();
        return rand.NextDouble() <= ProbabiliteContamination;
    }

    public virtual void Contaminer(Plante plante){}
}
