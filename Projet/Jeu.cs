public class Jeu
{
    private List<Plante> plantes = new List<Plante>();
    private Meteo meteo;
    private int taillePotager;
    private Terrain[,] grilleTerrains; // mieux vaux faire un tableau avec plante et et terrain dedans
    private Plante[,] grillePlantes;

    private const int LARGEUR = 10; // pas nécessaire
    private int poidsSable = 1, poidsTerre = 1, poidsArgile = 1;


    public Jeu()
    {
        Console.WriteLine("Bienvenue dans le simulateur de potager !");
        Console.Write("Taille du potager (nombre de cases) : ");
        taillePotager = int.Parse(Console.ReadLine());

        ChoisirRepartition();
        CreerGrilleTerrains();
        AfficherTerrainsInitial();
        BoucleDeJeu();
    }

    private void ChoisirRepartition()
    {
        Console.WriteLine("Quel terrain favoriser ? 1=Sable,2=Terre,3=Argile (Entrée=uniforme)");
        switch (Console.ReadLine())
        {
            case "1": poidsSable = 3; break;
            case "2": poidsTerre = 3; break;
            case "3": poidsArgile = 3; break;
            default: poidsTerre = 3 ; Console.WriteLine("Terre à été choisie"); break;
        }
        
    }

    private void CreerGrilleTerrains()
    {
        int lignes = (int)Math.Ceiling(taillePotager / (double)LARGEUR);
        grilleTerrains = new Terrain[lignes, LARGEUR];
        grillePlantes = new Plante[lignes, LARGEUR];
        var rand = new Random();
        int totalPoids = poidsSable + poidsTerre + poidsArgile;
        int count = 0;

        for (int i = 0; i < lignes; i++)
            for (int j = 0; j < LARGEUR; j++, count++)
                if (count < taillePotager)
                {
                    int tirage = rand.Next(totalPoids);
                    if (tirage < poidsSable)
                        grilleTerrains[i, j] = new TerrainSable(70, 80, 60, 22);
                    else if (tirage < poidsSable + poidsTerre)
                        grilleTerrains[i, j] = new TerrainTerre(70, 80, 50, 20);
                    else
                        grilleTerrains[i, j] = new TerrainArgile(70, 80, 40, 18);
                }
    }

    private void AfficherTerrainsInitial()
    {
        Console.Clear();
        Console.WriteLine("Terrains initiaux:\n");
        int lignes = grilleTerrains.GetLength(0), cols = grilleTerrains.GetLength(1);
        for (int i = 0; i < lignes; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                var t = grilleTerrains[i, j];
                Console.Write(t is TerrainSable ? "[S]" :
                          t is TerrainTerre ? "[T]" :
                          t is TerrainArgile ? "[A]" : "[ ]");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nAppuyez sur une touche pour démarrer...");
        Console.ReadKey();
    }

    public void BoucleDeJeu()
    {
        var rand = new Random();
        while (true)
        {
            GenererMeteo(rand);
            // Tour de toutes les plantes
            foreach (var plante in plantes.ToList())
                plante.PasserTour(meteo);

            // Retirer les plantes mortes
            var mortes = plantes.Where(p => p.EtatSante <= 0).ToList();
            foreach (var p in mortes)
            {
                RetirerPlante(p);
                Console.WriteLine($"{p.Nom} est morte et a été retirée du potager.");
            }

            AfficherPotager();
            AfficherPlantDetails();
            AfficherActions();
        }
    }

    private void GenererMeteo(Random rand)
    {
        if (rand.NextDouble() < 0.1)
        {
            Console.WriteLine("⚠️ Épisode météo extrême !");
            meteo = new Meteo(rand.Next(-15, 0), rand.Next(50, 100), true);
        }
        else
            meteo = new Meteo(rand.Next(-5, 35), rand.Next(0, 100), rand.NextDouble() > 0.8);

        Console.WriteLine($"Météo: {meteo.Temperature}°C, Précip: {meteo.Precipitations}%, Gel: {meteo.Gel}");
    }

    private void AfficherPotager()
    {
        Console.Clear();
        Console.WriteLine("Potager actuel:\n");
        int total = taillePotager;
        int lignes = (int)Math.Ceiling(total / (double)LARGEUR);
        string[] vis = Enumerable.Repeat("  ", total).ToArray();
        var emoji = new Dictionary<string, string> { { "Tomate", "🍅" }, { "Tulipe", "🌷" }, { "Chou", "🥬" }, { "Cactus", "🌵" } };

        int idx = 0;
        foreach (var p in plantes.Take(total)) vis[idx++] = emoji.GetValueOrDefault(p.Nom, "🌱");
        idx = 0;
        for (int i = 0; i < lignes; i++)
        {
            for (int j = 0; j < LARGEUR && idx < total; j++, idx++)
                Console.Write($"[{vis[idx]}]");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void AfficherPlantDetails()
    {
        Console.WriteLine("Détail des plantes :");
        if (!plantes.Any()) { Console.WriteLine("(aucune plante)"); return; }
        for (int i = 0; i < plantes.Count; i++)
        {
            var p = plantes[i];
            Console.WriteLine($"{i + 1}. {p.Nom} | Santé: {p.EtatSante}/10 | Eau: {p.EauActuelle}/{p.BesoinsEau} | Âge: {p.Age}/{p.EsperanceVie}");
        }
    }

    private void AfficherActions()
    {
        Console.WriteLine("Actions: 1=Arroser 2=Récolter 3=Planter 4=Quitter");
        switch (Console.ReadLine())
        {
            case "1": Arroser(); break;
            case "2": Recolter(); break;
            case "3": Planter(); break;
            case "4": Environment.Exit(0); break;
            default: Console.WriteLine("Choix invalide."); break;
        }
        Thread.Sleep(1000);
    }

    private void Arroser()
    {
        if (!plantes.Any()) { Console.WriteLine("Aucune plante à arroser."); return; }
        Console.WriteLine("Entrez les numéros des plantes à arroser (séparés par espaces), 0 pour aucune :");
        AfficherPlantDetails();
        var saisie = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saisie)) return;
        var tokens = saisie.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var t in tokens)
        {
            if (int.TryParse(t, out int idx) && idx > 0 && idx <= plantes.Count)
                plantes[idx - 1].Arroser();
        }
    }

    private void Recolter()
    {
        if (!plantes.Any()) { Console.WriteLine("Aucune plante à récolter."); return; }
        Console.WriteLine("Entrez les numéros des plantes à récolter (séparés par espaces), 0 pour aucune :");
        AfficherPlantDetails();
        var saisie = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saisie)) return;
        foreach (var t in saisie.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(t, out int idx) && idx > 0 && idx <= plantes.Count)
            {
                var plante = plantes[idx - 1];
                plante.Recolter();
                if (plante.NbRecoltesMax <= 0 || plante.EtatSante <= 0)
                {
                    RetirerPlante(plante);
                    Console.WriteLine($"{plante.Nom} a été retirée du potager après la dernière récolte.");
                }
            }
        }
    }

    private void Planter()
    {
        Console.WriteLine("Choix des plantes (1=Tomate 2=Tulipe 3=Chou 4=Cactus) :");
        var tokens = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (tokens == null) return;
        foreach (var t in tokens)
        {
            if (!int.TryParse(t, out int ch) || ch < 1 || ch > 4) continue;
            Console.WriteLine("Sur quel terrain? (1=Sable 2=Terre 3=Argile)");
            var w = Console.ReadLine();
            TerrainType wanted = w == "1" ? TerrainType.Sable : w == "2" ? TerrainType.Terre : TerrainType.Argile;
            if (PlanterSurType((PlanteType)ch, wanted))
                Console.WriteLine("Plante ajoutée.");
            else
                Console.WriteLine("Plus de place sur ce terrain.");
        }
    }

    private bool PlanterSurType(PlanteType type, TerrainType wanted)
    {
        int lignes = grilleTerrains.GetLength(0), cols = grilleTerrains.GetLength(1);
        for (int i = 0; i < lignes; i++)
            for (int j = 0; j < cols; j++)
                if (grillePlantes[i, j] == null &&
                   ((wanted == TerrainType.Sable && grilleTerrains[i, j] is TerrainSable) ||
                    (wanted == TerrainType.Terre && grilleTerrains[i, j] is TerrainTerre) ||
                    (wanted == TerrainType.Argile && grilleTerrains[i, j] is TerrainArgile)))
                {
                    Plante p = type switch
                    {
                        PlanteType.Tomate => new PlanteTomate(grilleTerrains[i, j]),
                        PlanteType.Tulipe => new PlanteTulipe(grilleTerrains[i, j]),
                        PlanteType.Chou => new PlanteChou(grilleTerrains[i, j]),
                        PlanteType.Cactus => new PlanteCactus(grilleTerrains[i, j]),
                        _ => null
                    };
                    if (p != null)
                    {
                        grillePlantes[i, j] = p;
                        plantes.Add(p);
                        return true;
                    }
                }
        return false;
    }

    private void RetirerPlante(Plante p)
    {
        plantes.Remove(p);
        int lignes = grillePlantes.GetLength(0), cols = grillePlantes.GetLength(1);
        for (int i = 0; i < lignes; i++)
            for (int j = 0; j < cols; j++)
                if (grillePlantes[i, j] == p) grillePlantes[i, j] = null;
    }
}

public enum PlanteType { Tomate = 1, Tulipe, Chou, Cactus }
public enum TerrainType { Sable, Terre, Argile }