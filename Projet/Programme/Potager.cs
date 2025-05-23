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
        while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 && result > 3))
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
                Terrain terrain = TirerTerrainAuSort();
                grillePotager[i, j] = new CasePotager(terrain, Meteo);
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
            else { t = new TerrainArgile(); }
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

    public void AfficherPotager()
    {
        for (int i = 0; i < PotagerLongueur; i++)
        {
            for (int j = 0; j < PotagerLargeur; j++)
            {
                Console.Write(GrillePotager[i, j].AfficherCase());
            }
            Console.WriteLine();
        }
    }

    public void ChoisirPlanter()
    {
        Console.WriteLine("Voulez vous planter une plante ?");
        string answer;
        do
        {
            Console.WriteLine("A quelle position souhaitez vous planter votre plante, (entrer la case en hauteur puis largeur)");
            int positionX = Convert.ToInt32(Console.ReadLine()!);
            int positionY = Convert.ToInt32(Console.ReadLine()!);

            Plante p = ChoisirPlante(); // on récupère la plante choisie par l'utilisateur

            if (Planter(positionX, positionY, p))
            {
                Console.WriteLine("votre {answer} a été planté ! ");
            }
            else
            {
                Console.WriteLine("Il y avait déjà une plante à cette position");
            }

            Console.WriteLine("Souhaitez-vous en ajouter un autre? (oui/non)");
            answer = Console.ReadLine()!;
        } while (answer == "oui");
    }

    public Plante ChoisirPlante()
    {
        string answer;
        Console.WriteLine("Quelle type de plante voulez vous planter, (tulipe/tomate/cactus/chou)");
        answer = Console.ReadLine()!;

        if (answer == "tulipe")
        {
            PlanteTulipe p = new PlanteTulipe();
            return p;
        }
        else if (answer == "tomate")
        {
            PlanteTomate p = new PlanteTomate();
            return p;
        }
        else if (answer == "cactus")
        {
            PlanteCactus p = new PlanteCactus();
            return p;
        }
        else
        {
            PlanteChou p = new PlanteChou();
            return p;
        }
    }


    public bool Planter(int x, int y, Plante p)
    {
        if (GrillePotager[x, y].EstLibre())
        {
            GrillePotager[x, y].Plante = p;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void JouerTourPotager()
    {
        if (Meteo.CatastropheEnCours)
        {
            //JouerCatastrophe();
        }
        else
        {

        }
    }

    public void JouerModeUrgence()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            if (i % 2 == 0)
            {
                Console.WriteLine("🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 ");
                Console.WriteLine("-------------URGENCE-------------");
                Console.WriteLine("🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 🚨 ");
            }
            else
            {
                Console.WriteLine(
                     "\t        🔺       \n" +
                     "\t       🔺🔺      \n" +
                     "\t      🔺  🔺     \n" +
                     "\t     🔺 🔥 🔺    \n" +
                     "\t    🔺  🔥  🔺   \n" +
                     "\t   🔺   🔥   🔺  \n" +
                     "\t  🔺    🔥    🔺 \n" +
                     "\t 🔺🔺🔺🔺🔺🔺🔺🔺\n");
            }
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine("LES SOLDATS DU FEU VOUS ATTAQUE");
        Console.Write("Vite ! repondez a leur question !! Ils bruleront votre potager sinon !! 🔥🔥");
        Questionnaire q = new Questionnaire();
        if (q.PoserQuestion())
        {
            Console.WriteLine("\nOuf, vous l'avez échappé belle");
            System.Threading.Thread.Sleep(1000);
        }
        else
        {
            SupprimerCase();
            Console.WriteLine("\nOH NON, Ils ont brulé votre potager");
            System.Threading.Thread.Sleep(1000);
        }
    }

    public void SupprimerCase() // permet de bloquer une ligne
    {
        int l = rnd.Next(PotagerLargeur); // on tire au hasard une ligne
        for (int i = 0; i < PotagerLongueur; i++)
        {
            TerrainBrule t = new TerrainBrule(Meteo);
            PlanteBloque p = new PlanteBloque();
            CasePotager bloqueur = new CasePotager(t,Meteo,p);
            GrillePotager[l, i] = bloqueur;
        }
    }
}