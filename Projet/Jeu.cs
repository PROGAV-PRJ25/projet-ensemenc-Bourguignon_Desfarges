public class Jeu
{
    public void AfficherRegles()
    {
        string phrase = "";
        phrase += "Ce jeu est un simulateur de potager dans l'univers d'Avatar le Dernier maître de l'air. Votre but est de maximiser vos récoltes. \nLe jeu se déroulera sur 15 tours.\nPour chaques tour vous aurez droit a 4 actions maximum. Une fois ces 4 actions ou moins réalisés, une semaine se déroulera et vous pourrez réalisé le prochain tour\nLa réussite de votre partie dépendra de votre capacité à gérer votre potager tout en vous adaptant aux différentes variables extérieurs comme la météo ou les maladies ! \n Bon courage !.";
    }

    public void ChoisirAfficherRegles()
    {
        Console.WriteLine("Voulez vous affichez les règles du jeu : pour oui taper 1, sinon taper 2");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 && result > 2))
        {
            Console.WriteLine("1 oui, 2 non");
        }  
    }
    
//     private List<Plante> plantes = new List<Plante>();
    //     private Meteo meteo;
    //     private int taillePotager;
    //     private CasePotager[,] grillePotager;

    //     private int poidsSable = 1, poidsTerre = 1, poidsArgile = 1;


    //     public Jeu()
    //     {
    //         Console.WriteLine("Bienvenue dans le simulateur de potager !");
    //         Console.Write("Taille du potager (nombre de cases) : ");
    //         int result;
    //         while (!int.TryParse(Console.ReadLine(), out result) || result < 0)
    //         {
    //             Console.WriteLine("Veuillez Rentrez un nombre convenable");
    //         }
    //         taillePotager = result;

    //         CreerGrillePotager();
    //         AfficherTerrainsInitial();
    //         BoucleDeJeu();
    //     }

    //     private void CreerGrillePotager()
    // {
    //     int lignes = (int)Math.Ceiling(Math.Sqrt(taillePotager));
    //     int colonnes = (int)Math.Ceiling((double)taillePotager / lignes);
    //     grillePotager = new CasePotager[lignes, colonnes];
    //     var rand = new Random();
    //     int totalPoids = poidsSable + poidsTerre + poidsArgile;
    //     int count = 0;

    //     for (int i = 0; i < lignes; i++) ////////////////// TRUC A FAIRE : REMPLACER LES TERRAINS PAR LES BONS TRUC
    //     {
    //         for (int j = 0; j < colonnes; j++, count++)
    //         {
    //             if (count < taillePotager)
    //             {
    //                 int tirage = rand.Next(totalPoids);
    //                 Terrain terrain = tirage < poidsSable
    //                     ? new TerrainSable(70, 80, 60, 22)
    //                     : tirage < poidsSable + poidsTerre
    //                         ? new TerrainTerre(70, 80, 50, 20)
    //                         : new TerrainArgile(70, 80, 40, 18);
    //                 grillePotager[i, j] = new CasePotager(terrain);
    //             }
    //         }
    //     }
    // }
    //     private void AfficherTerrainsInitial()
    // {
    //     Console.Clear();
    //     Console.WriteLine("Terrains initiaux:\n");
    //     int lignes = grillePotager.GetLength(0), colonnes = grillePotager.GetLength(1);
    //     for (int i = 0; i < lignes; i++)
    //     {
    //         for (int j = 0; j < colonnes; j++)
    //         {
    //             var t = grillePotager[i, j]?.Terrain;
    //             Console.Write(t is TerrainSable ? "[S]" :
    //                       t is TerrainTerre ? "[T]" :
    //                       t is TerrainArgile ? "[A]" : "[ ]");
    //         }
    //         Console.WriteLine();
    //     }
    //     Console.WriteLine("\nAppuyez sur une touche pour démarrer...");
    //     Console.ReadKey();
    // }

    //     public void BoucleDeJeu()
    //     {
    //         var rand = new Random();
    //         while (true)
    //         {
    //             GenererMeteo(rand);
    //             // Tour de toutes les plantes
    //             foreach (var plante in plantes.ToList())
    //             // Chance aléatoire de tomber malade
    //             if (rand.NextDouble() < 0.2) // 20% de chance
    //             {
    //                 Maladies maladie = GenererMaladiePourPlante(plante);
    //                 if (maladie != null)
    //                 {
    //                     //plante.TomberMalade(maladie);
    //                 }

    //                 plante.PasserTour(meteo);
    //             }

    //             // Retirer les plantes mortes
    //             var mortes = plantes.Where(p => p.EtatSante <= 0).ToList();
    //             foreach (var p in mortes)
    //             {
    //                 RetirerPlante(p);
    //                 Console.WriteLine($"{p.Nom} est morte et a été retirée du potager.");
    //             }

    //             AfficherPotager();
    //             AfficherPlantDetails();
    //             AfficherActions();
    //         }
    //     }

    //     private void AfficherPotager()
    // {
    //     Console.Clear();
    //     Console.WriteLine("Potager actuel:\n");
    //     int lignes = grillePotager.GetLength(0), colonnes = grillePotager.GetLength(1);
    //     int total = taillePotager;
    //     string[] vis = Enumerable.Repeat("  ", total).ToArray();
    //     var emoji = new Dictionary<string, string> { { "Tomate", "🍅" }, { "Tulipe", "🌷" }, { "Chou", "🥬" }, { "Cactus", "🌵" } };
    //     int idx = 0;
    //         foreach (var p in plantes.Take(total)) vis[idx++] = emoji.GetValueOrDefault(p.Nom, "🌱");
    //         idx = 0;
    //         for (int i = 0; i < lignes; i++)
    //         {
    //             for (int j = 0; j < total && idx < total; j++, idx++)
    //                 Console.Write($"[{vis[idx]}]");
    //         }
    //         Console.WriteLine();

    //     Console.WriteLine();
    // }

    //     private void AfficherPlantDetails()
    //     {
    //         Console.WriteLine("Détail des plantes :");
    //         if (!plantes.Any()) { Console.WriteLine("(aucune plante)"); return; }
    //         for (int i = 0; i < plantes.Count; i++)
    //         {
    //             var p = plantes[i];
    //             Console.WriteLine($"{i + 1}. {p.Nom} | Santé: {p.EtatSante}/10 | Eau: {p.EauActuelle}/{p.BesoinsEau} | Âge: {p.Age}/{p.EsperanceVie}");
    //         }
    //     }

    //     private void AfficherActions()
    //     {
    //         Console.WriteLine("Actions: 1=Arroser 2=Récolter 3=Planter 4=Quitter");
    //         switch (Console.ReadLine())
    //         {
    //             case "1": Arroser(); break;
    //             case "2": Recolter(); break;
    //             case "3": Planter(); break;
    //             case "4": Environment.Exit(0); break;
    //             default: Console.WriteLine("Choix invalide."); break;
    //         }
    //         Thread.Sleep(1000);
    //     }


    //     private void Arroser()
    //     {
    //         if (!plantes.Any()) { Console.WriteLine("Aucune plante à arroser."); return; }
    //         Console.WriteLine("Entrez les numéros des plantes à arroser (séparés par espaces), 0 pour aucune :");
    //         AfficherPlantDetails();
    //         var saisie = Console.ReadLine();
    //         if (string.IsNullOrWhiteSpace(saisie)) return;
    //         var tokens = saisie.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //         foreach (var t in tokens)
    //         {
    //             if (int.TryParse(t, out int idx) && idx > 0 && idx <= plantes.Count)
    //                 plantes[idx - 1].Arroser();
    //         }
    //     }

    //     private void Recolter()
    //     {
    //         if (!plantes.Any()) { Console.WriteLine("Aucune plante à récolter."); return; }
    //         Console.WriteLine("Entrez les numéros des plantes à récolter (séparés par espaces), 0 pour aucune :");
    //         AfficherPlantDetails();
    //         var saisie = Console.ReadLine();
    //         if (string.IsNullOrWhiteSpace(saisie)) return;
    //         foreach (var t in saisie.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    //         {
    //             if (int.TryParse(t, out int idx) && idx > 0 && idx <= plantes.Count)
    //             {
    //                 var plante = plantes[idx - 1];
    //                 plante.Recolter();
    //                 if (plante.NbRecoltesMax <= 0 || plante.EtatSante <= 0)
    //                 {
    //                     RetirerPlante(plante);
    //                     Console.WriteLine($"{plante.Nom} a été retirée du potager après la dernière récolte.");
    //                 }
    //             }
    //         }
    //     }

    //     private void Planter()
    //     {
    //         Console.WriteLine("Choix des plantes (1=Tomate 2=Tulipe 3=Chou 4=Cactus) :");
    //         var tokens = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //         if (tokens == null) return;
    //         foreach (var t in tokens)
    //         {
    //             if (!int.TryParse(t, out int ch) || ch < 1 || ch > 4) continue;
    //             Console.WriteLine("Sur quel terrain? (1=Sable 2=Terre 3=Argile)");
    //             var w = Console.ReadLine();
    //             TerrainType wanted = w == "1" ? TerrainType.Sable : w == "2" ? TerrainType.Terre : TerrainType.Argile;
    //             if (PlanterSurType((PlanteType)ch, wanted))
    //                 Console.WriteLine("Plante ajoutée.");
    //             else
    //                 Console.WriteLine("Plus de place sur ce terrain.");
    //         }
    //     }

    //     private bool PlanterSurType(PlanteType type, TerrainType wanted)
    // {
    //     int lignes = grillePotager.GetLength(0), colonnes = grillePotager.GetLength(1);
    //     for (int i = 0; i < lignes; i++)
    //     {
    //         for (int j = 0; j < colonnes; j++)
    //         {
    //             var casePotager = grillePotager[i, j];
    //             if (casePotager != null && casePotager.EstLibre() &&
    //                ((wanted == TerrainType.Sable && casePotager.Terrain is TerrainSable) ||
    //                 (wanted == TerrainType.Terre && casePotager.Terrain is TerrainTerre) ||
    //                 (wanted == TerrainType.Argile && casePotager.Terrain is TerrainArgile)))
    //             {
    //                 Plante p = type switch
    //                 {
    //                     PlanteType.Tomate => new PlanteTomate(casePotager.Terrain),
    //                     PlanteType.Tulipe => new PlanteTulipe(casePotager.Terrain),
    //                     PlanteType.Chou => new PlanteChou(casePotager.Terrain),
    //                     PlanteType.Cactus => new PlanteCactus(casePotager.Terrain),
    //                     _ => null
    //                 };
    //                 if (p != null)
    //                 {
    //                     casePotager.Plante = p;
    //                     plantes.Add(p);
    //                     return true;
    //                 }
    //             }
    //         }
    //     }
    //     return false;
    // }

    //     private void RetirerPlante(Plante p)
    // {
    //     plantes.Remove(p);
    //     int lignes = grillePotager.GetLength(0), colonnes = grillePotager.GetLength(1);
    //     for (int i = 0; i < lignes; i++)
    //     {
    //         for (int j = 0; j < colonnes; j++)
    //         {
    //             if (grillePotager[i, j]?.Plante == p)
    //             {
    //                 grillePotager[i, j].Plante = null;
    //             }
    //         }
    //     }
    // }
}

// public enum PlanteType { Tomate = 1, Tulipe, Chou, Cactus }
// public enum TerrainType { Sable, Terre, Argile }