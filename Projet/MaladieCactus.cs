public class MaladieCactus : Maladies
{
    public MaladieCactus() 
        : base("Pourriture molle", 0.2, "Taches brunes et ramollissement des tissus.")
    {
    }

    public override void Contaminer(Plante plante)
    {
        if (plante is PlanteCactus && new Random().NextDouble() < ProbabiliteContamination)
        {
            plante.EtatSante -= 15; // Impact modéré pour les cactus
            plante.BesoinsEau += 10; // Augmente le besoin en eau
            Console.WriteLine($"{plante.Nom} est contaminée par {Nom}!");
            Console.WriteLine($"Symptômes: {Symptomatologie}");
        }
    }
}