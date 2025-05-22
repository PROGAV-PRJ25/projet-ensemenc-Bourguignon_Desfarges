using System.Security.Cryptography.X509Certificates;

public class Potager
{
    Random rnd = new Random();
    public Meteo Meteo; // Il y a une seule et unique météo sur tout le Terrain, cependant certaines variables comme l'ensoleillement variront en fonction des cases du potager
    public int PotagerLongueur { get; private set; }
    public int PotagerLargeur { get; private set; }
    public int TerrainFavori { get; set; } // Terrain favori 1 = sable; 2 = terre; 3 = argile
    protected CasePotager[,] GrillePotager { get; set; }

    public Potager(Meteo meteo)
    {
        Meteo = meteo;
        PotagerLongueur = RecupererTaillePotager(true);
        PotagerLargeur = RecupererTaillePotager(false);
        TerrainFavori = FavoriserTerrain();
        GrillePotager = CreationPotager();
    }
    public int RecupererTaillePotager(bool test) // permet de récupérer la taille du potager
    {
        string mot;
        if (test) { mot = "longueur"; }
        else { mot = "largeur"; }
        Console.Write($"Quelle est la {mot} de votre potager (nombre de cases) : ");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || result < 0)
        {
            Console.WriteLine("Veuillez Rentrez un nombre convenable");
        }
        return result;
    }

    public int FavoriserTerrain()
    {
        Console.WriteLine("Quelle terrain voulez vous favoriser. Votre choix influencera le taux d'apparition de ce terrain (il aura 2 fois plus de chance d'apparaître).\nPour un Terrain plutot sableux, tapez 1,\nPour un Terrain plutot terreux, tapez 2,\nPour un Terrain plutot argileux, tapez 3. ");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || ( result < 0 && result > 3))
        {
            Console.WriteLine("Veuillez rentrez 1(sable), 2(terre) ou 3(argile) ");
        }
        return result;
    }



    public CasePotager[,] CreationPotager()
    {
        CasePotager[,] grillePotager = new CasePotager[PotagerLongueur, PotagerLargeur];
        for (int i = 0; i < PotagerLongueur; i++)
        {
            for (int j = 0; j < PotagerLargeur; j++)
            {
                Terrain ter = TirerTerrainAuSort();
                grillePotager[i, j] = new CasePotager(ter, Meteo);
            }
        }
        return grillePotager;
    }

    public Terrain TirerTerrainAuSort() // Permet de tirer au sort un terrain entre les 3 types de terrains
    {
        int test = rnd.Next(4);
        Terrain t;
        if (TerrainFavori == 1)
        {
            if (test < 2) // une chance sur deux pour avoir le terrain choisi par l'utilisateur
            { t = new TerrainSable(); }
            else if (test == 2) { t = new TerrainTerre(); }
            else { t = new TerrainSable(); }
        }
        else if (TerrainFavori == 2)
        {
            if (test < 2) { t = new TerrainTerre(); }
            else if (test == 2) { t = new TerrainSable(); }
            else { t = new TerrainArgile(); }
        }
        else
        {
            if (test < 2) { t = new TerrainArgile(); }
            else if (test == 2) { t = new TerrainSable(); }
            else { t = new TerrainTerre(); }
        }
        return t;
    }

    private void AfficherPotager()
    {
        //Console.Clear();
        Console.WriteLine("Potager actuel:\n");
        string[] vis = Enumerable.Repeat("  ", total).ToArray();
        var emoji = new Dictionary<string, string> { { "Tomate", "🍅" }, { "Tulipe", "🌷" }, { "Chou", "🥬" }, { "Cactus", "🌵" } };
        int idx = 0;
            foreach (var p in plantes.Take(total)) vis[idx++] = emoji.GetValueOrDefault(p.Nom, "🌱");
            idx = 0;
            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < total && idx < total; j++, idx++)
                    Console.Write($"[{vis[idx]}]");
            }
            Console.WriteLine();

        Console.WriteLine();
    }
}