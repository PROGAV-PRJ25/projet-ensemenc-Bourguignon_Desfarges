public class Jeu
{
    private List<Plante> plantes = new List<Plante>();
    private Terrain terrain;
    private Meteo meteo;
    private int taillePotager;

    public Jeu()
    {
        Console.WriteLine("Bienvenue dans le simulateur de potager !");
        Console.WriteLine("Quelle taille fait votre potager (en nombre de cases) ?");
        taillePotager = int.Parse(Console.ReadLine());

        ChoisirTerrain();

        ChoisirPlantes();
    }

    private void ChoisirTerrain()
    {
        Console.WriteLine("Choisissez un type de terrain :");
        Console.WriteLine("1. Sable");
        Console.WriteLine("2. Terre");
        Console.WriteLine("3. Argile");

        var choixTerrain = Console.ReadLine();
        switch (choixTerrain)
        {
            case "1":
                terrain = new TerrainSable(70, 80, 60, 22);
                break;
            case "2":
                terrain = new TerrainTerre(70, 80, 50, 20);
                break;
            case "3":
                terrain = new TerrainArgile(70, 80, 40, 18);
                break;
            default:
                Console.WriteLine("Choix invalide, terrain par défaut (Terre).");
                terrain = new TerrainTerre(70, 80, 50, 20);
                break;
        }
    }

    private void ChoisirPlantes()
    {
        Console.WriteLine("Que voulez‑vous planter ?");
        Console.WriteLine(" 1. Tomate  (Comestible)");
        Console.WriteLine(" 2. Tulipe  (Ornementale)");
        Console.WriteLine(" 3. Chou    (Comestible)");
        Console.WriteLine(" 4. Cactus  (Ornementale)");
        Console.WriteLine("Tapez les numéros des plantes séparés par des espaces (ou Entrée pour aucune) :");

        // lecture de la ligne entière
        string? ligne = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(ligne))
        {
            Console.WriteLine("Aucune plante ajoutée.");
            return;
        }

        // découper la saisie sur les espaces
        string[] choix = ligne.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string c in choix)
        {
            switch (c)
            {
                case "1":
                    plantes.Add(new PlanteComestible("Tomate", "Annuelle", terrain, "Printemps", 60, 80, 22, 1, 7,
                        new Maladies("Mildiou", 0.3, "taches jaunes sur les feuilles"), 2, 10, 5, "Comestible"));
                    Console.WriteLine("Tomate plantée.");
                    break;

                case "2":
                    plantes.Add(new PlanteOrnementale("Tulipe", "Vivace", terrain, "Automne", 40, 90, 18, 2, 10,
                        new Maladies("Rouille", 0.2, "taches rouges sur les feuilles"), 5, 8, 3, "Ornementale"));
                    Console.WriteLine("Tulipe plantée.");
                    break;

                case "3":
                    plantes.Add(new PlanteComestible("Chou", "Vivace", terrain, "Hiver", 50, 60, 15, 2, 6,
                        new Maladies("Peronospora", 0.1, "taches blanches sur les feuilles"), 3, 9, 4, "Comestible"));
                    Console.WriteLine("Chou planté.");
                    break;

                case "4":
                    plantes.Add(new PlanteOrnementale("Cactus", "Vivace", terrain, "Printemps", 20, 100, 25, 1, 12,
                        new Maladies("Acariens", 0.15, "points noirs"), 7, 10, 2, "Ornementale"));
                    Console.WriteLine("Cactus planté.");
                    break;

                default:
                    Console.WriteLine($"\"{c}\" n’est pas un choix valide – ignoré.");
                    break;
            }
        }

        Console.WriteLine($"{plantes.Count} plante(s) au total dans le potager.");
    }


    public void BoucleDeJeu()
    {
        Random rand = new Random();
        while (true)
        {
            meteo = new Meteo(rand.Next(-5, 35), rand.Next(0, 100), rand.NextDouble() > 0.8);
            Console.WriteLine($"Météo actuelle : Température {meteo.Temperature}°C, Précipitations {meteo.Precipitations}%, Gel : {meteo.Gel}");

            foreach (var plante in plantes)
            {
                plante.AppliquerConditionsMeteo(meteo);
                if (plante.EtatSante <= 0)
                {
                    Console.WriteLine($"{plante.Nom} est morte !");
                }
                else
                {
                    Console.WriteLine($"{plante.Nom} état de santé : {plante.EtatSante}/10");
                }
            }

            AfficherPotager();


            Console.WriteLine("Que voulez‑vous faire ?");
            Console.WriteLine("1. Arroser ");
            Console.WriteLine("2. Récolter ");
            Console.WriteLine("3. Quitter");

            var choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    if (plantes.Count == 0)
                    {
                        Console.WriteLine("Aucune plante dans le potager.");
                        break;
                    }

                    Console.WriteLine("Quelle plante voulez‑vous arroser ?");
                    Console.WriteLine("0. Toutes les plantes");
                    for (int i = 0; i < plantes.Count; i++)
                        Console.WriteLine($"{i + 1}. {plantes[i].Nom} (santé {plantes[i].EtatSante}/10)");

                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        if (index == 0)
                        {
                            foreach (var p in plantes) p.Arroser();
                        }
                        else if (index >= 1 && index <= plantes.Count)
                        {
                            plantes[index - 1].Arroser();
                        }
                        else
                        {
                            Console.WriteLine("Numéro invalide.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrée non valide.");
                    }
                    break;

                case "2":
                    if (plantes.Count == 0)
                    {
                        Console.WriteLine("Aucune plante à récolter.");
                        break;
                    }

                    Console.WriteLine("Quelle plante voulez‑vous récolter ?");
                    Console.WriteLine("0. Toutes les plantes");
                    for (int i = 0; i < plantes.Count; i++)
                        Console.WriteLine($"{i + 1}. {plantes[i].Nom} (récoltes restantes {plantes[i].NbRecoltesMax})");

                    if (int.TryParse(Console.ReadLine(), out int choixRecolte))
                    {
                        if (choixRecolte == 0)
                            foreach (var p in plantes) p.Recolter();
                        else if (choixRecolte >= 1 && choixRecolte <= plantes.Count)
                            plantes[choixRecolte - 1].Recolter();
                        else
                            Console.WriteLine("Numéro invalide.");
                    }
                    else
                    {
                        Console.WriteLine("Entrée non valide.");
                    }
                    break;

                case "3":
                    return;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }


            System.Threading.Thread.Sleep(3000);
        }
    }

    // dictionnaire : nom (clé) → emoji (valeur)
    private readonly Dictionary<string, string> emojiPlante = new()
{
    { "Tomate", "🍅" },
    { "Tulipe", "🌷" },
    { "Chou",    "🥬" },
    { "Cactus",  "🌵" }
};

    private void AfficherPotager()
    {
        Console.Clear();
        Console.WriteLine("Voici votre potager :\n");

        const int largeur = 10;
        int nbCases = taillePotager;
        int nbLignes = (int)Math.Ceiling(nbCases / (double)largeur);

        string[] grille = Enumerable.Repeat("  ", nbCases).ToArray();

        for (int i = 0; i < plantes.Count && i < nbCases; i++)
        {
            var p = plantes[i];
            grille[i] = emojiPlante.TryGetValue(p.Nom, out string em) ? em : "🌱";
        }

        int index = 0;
        for (int ligne = 0; ligne < nbLignes; ligne++)
        {
            for (int col = 0; col < largeur && index < nbCases; col++, index++)
            {
                Console.Write('[' + grille[index] + ']');
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nDétail des plantes :");
        if (plantes.Count == 0)
        {
            Console.WriteLine("(aucune plante)");
        }
        else
        {
            foreach (var p in plantes)
            {
                string em = emojiPlante.TryGetValue(p.Nom, out string e) ? e : "🌱";
                Console.WriteLine($"{em} {p.Nom,-10}  Santé {p.EtatSante}/10  Récoltes {p.NbRecoltesMax}");
            }
        }
    }

}