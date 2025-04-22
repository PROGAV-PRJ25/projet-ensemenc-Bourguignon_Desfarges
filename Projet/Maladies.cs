public class Maladies
{
    public string Nom { get; set; }
    public double ProbabiliteContamination { get; set; } // entre 0 et 1
    public string Symptomatologie { get; set; }
    public Maladies(string nom, double prob, string symptomes)
    {
        Nom = nom;
        ProbabiliteContamination = prob;
        Symptomatologie = symptomes;
    }

    public bool PeutContaminer()
    {
        Random rand = new Random();
        return rand.NextDouble() <= ProbabiliteContamination;
    }
}
