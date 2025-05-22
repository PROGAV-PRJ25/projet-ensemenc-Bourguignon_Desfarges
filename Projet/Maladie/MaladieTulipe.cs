// public class MaladieTulipe : Maladies
// {
//     public MaladieTulipe() 
//         : base("Virus de la mosaïque", 0.25, "Décoloration et motifs en mosaïque sur les feuilles.")
//     {
//     }

//     public override void Contaminer(Plante plante)
//     {
//         if (plante is PlanteTulipe && new Random().NextDouble() < ProbabiliteContamination)
//         {
//             plante.EtatSante -= 20; // Réduit la santé des tulipes
//             plante.BesoinsEau -= 5; // Diminue légèrement le besoin en eau
//             Console.WriteLine($"{plante.Nom} est contaminée par {Nom}!");
//             Console.WriteLine($"Symptômes: {Symptomatologie}");
//         }
//     }
// }