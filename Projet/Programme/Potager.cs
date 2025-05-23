using System.Security.Cryptography.X509Certificates;

public class Potager
{
    Random rnd = new Random();
    public Meteo Meteo; // Il y a une seule et unique météo sur tout le Terrain, cependant certaines variables comme l'ensoleillement variront en fonction des cases du potager
    public int PotagerLongueur { get; private set; }
    public int PotagerLargeur { get; private set; }
    public int TerrainFavori { get; set; } // Terrain favori 1 = sable; 2 = terre; 3 = argile
    protected CasePotager[,] GrillePotager { get; set; }
    public List<Plante> ListePlante { get; set; } = new List<Plante> { };
    public int Action { get; set; } = 5;

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
        Console.WriteLine("Vous allez pouvoir choisir la taille de votre potager \n(taille minimale 5x5)\n(taille maximale 12x12)\n\n");
        string mot;
        if (test) { mot = "hauteur"; }
        else { mot = "largeur"; }
        Console.Write($"Quelle est la {mot} de votre potager (nombre de cases) : ");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || result < 5 || result > 12)
        {
            Console.WriteLine("Veuillez Rentrez un nombre convenable");
        }
        Console.Clear();
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
        Console.Clear();
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
        Console.WriteLine("Voulez vous planter une plante (oui/non) ?");
        string answer;
        answer = Console.ReadLine()!;
        while (answer == "oui" && Action > 0)
        {
            Console.WriteLine("A quelle position souhaitez vous planter votre plante, entrer la case en hauteur");

            int positionX = Convert.ToInt32(Console.ReadLine()!);
            while (positionX <= 0 || positionX > PotagerLongueur)
            {
                Console.WriteLine("Veuillez entrez une hauteur qui soit sur le potager");
                positionX = Convert.ToInt32(Console.ReadLine()!);
            }
            positionX--;

            Console.WriteLine("A quelle largeur souhaitez vous planter votre plante");
            int positionY = Convert.ToInt32(Console.ReadLine()!);
            while (positionY <= 0 || positionY > PotagerLongueur)
            {
                Console.WriteLine("Veuillez entrez une largeur qui soit sur le potager");
                positionY = Convert.ToInt32(Console.ReadLine()!);
            }
            positionY--;


            Plante p = ChoisirPlante(); // on récupère la plante choisie par l'utilisateur

            if (Planter(positionX, positionY, p))
            {
                Console.Clear();
                Console.WriteLine($"votre {p.Nom} a été planté ! ");
                Action--;
                AfficherPotager();
            }
            else
            {
                Console.WriteLine("Il y avait déjà une plante à cette position");
            }

            Console.WriteLine("Souhaitez-vous en ajouter une autre? (oui/non)");
            answer = Console.ReadLine()!;
        }
        if (Action == 0)
        {
            Console.WriteLine("Vous avez réalisé toute vos actions\nPassage au tour suivant");
            System.Threading.Thread.Sleep(1000);
        }
    }

    public Plante ChoisirPlante()
    {
        string answer;
        Console.WriteLine("Quelle type de plante voulez vous planter, (tulipe/tomate/cactus/chou)");
        answer = Console.ReadLine()!;

        if (answer == "tulipe")
        {
            PlanteTulipe p = new PlanteTulipe();
            ListePlante.Add(p);
            return p;
        }
        else if (answer == "tomate")
        {
            PlanteTomate p = new PlanteTomate();
            ListePlante.Add(p);
            return p;
        }
        else if (answer == "cactus")
        {
            PlanteCactus p = new PlanteCactus();
            ListePlante.Add(p);
            return p;
        }
        else
        {
            PlanteChou p = new PlanteChou();
            ListePlante.Add(p);
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
            Console.WriteLine("Vous ne pouvez rien planter ici");
            return false;
        }
    }

    public void JouerTourPotager()
    {
        //JouerTourPlante(); // actualise l'état de toutes les plantes
        RetirerPlanteMortePotager();
        Action = 5; // on réactualise le nombre d'action
        ChoisirPlanter();
        Console.Clear();
        Console.WriteLine("Voici votre potager à la fin du tour ! ");
        AfficherPotager();
    }

    public void JouerTourPlante()
    {
        
        for (int i = 0; i < PotagerLongueur; i++)
        {
            for (int j = 0; j < PotagerLargeur; j++)
            {
                var plante = GrillePotager[i, j].Plante;
                if (plante != null)
                {
                    plante.TourPlante();
                }
            }
        } 
    }
    public void RetirerPlanteMortePotager()
    {
        for (int i = 0; i < PotagerLongueur; i++)
        {
            for (int j = 0; j < PotagerLargeur; j++)
            {
                GrillePotager[i, j].RetirerPlanteMorte();
            }
        }
    }


    public void AfficherPlante()
    {
        // afficher toutes les statistiques des plantes
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
        Console.WriteLine();
        Console.WriteLine("LES SOLDATS DU FEU VOUS ATTAQUE\n");
        Console.Write("Vite ! repondez a leur question !! Ils bruleront votre potager sinon !! 🔥🔥\n");
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
        Console.Clear();
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