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
    public virtual void Contaminer(Plante plante)
    {
        if (new Random().NextDouble() < ProbabiliteContamination)
        {
            plante.EtatSante -= 20; // Réduit la santé de la plante
            Console.WriteLine($"{plante.Nom} est contaminée par {Nom}!");
            Console.WriteLine($"Symptômes: {Symptomatologie}");
        }
    }
}
