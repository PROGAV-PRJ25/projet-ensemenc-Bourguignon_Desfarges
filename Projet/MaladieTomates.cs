public class MaladieTomate : Maladies
{
    public MaladieTomate() 
        : base("Mildiou", 0.4, "Taches brunes sur les feuilles et pourriture des fruits.")
    {
    }

    public override void Contaminer(Plante plante)
    {
        if (plante is PlanteTomate && new Random().NextDouble() < ProbabiliteContamination)
        {
            plante.EtatSante -= 25; // Réduit la santé des tomates
            plante.NbRecoltesMax -= 1; // Réduit la production de fruits
            Console.WriteLine($"{plante.Nom} est contaminée par {Nom}!");
            Console.WriteLine($"Symptômes: {Symptomatologie}");
        }
    }
}