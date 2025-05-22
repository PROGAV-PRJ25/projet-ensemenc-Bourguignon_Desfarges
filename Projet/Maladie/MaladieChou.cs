// public class MaladieChou : Maladies
// {
//     public MaladieChou() 
//         : base("Hernie du chou", 0.3, "Déformation des racines et jaunissement des feuilles.")
//     {
//     }

//     public override void Contaminer(Plante plante)
//     {
//         if (plante is PlanteChou && new Random().NextDouble() < ProbabiliteContamination)
//         {
//             plante.EtatSante -= 30; // Réduit davantage la santé pour les choux
//             Console.WriteLine($"{plante.Nom} est contaminée par {Nom}!");
//             Console.WriteLine($"Symptômes: {Symptomatologie}");
//         }
//     }
// }