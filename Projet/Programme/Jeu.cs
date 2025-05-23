using System.Xml.Serialization;

public class Jeu
{
    Random rnd = new Random();
    public int Semaine { get; set; } // repaire temporelle 
    public int Nation { get; set; } // choix de la nation (du mode de jeu)

    public Jeu()
    {
        Semaine = 1;
        Nation = 0;
    }
    public void AfficherRegles()
    {
        Console.Clear();
        string phrase = "";
        phrase += "Ce jeu est un simulateur de potager dans l'univers d'Avatar le Dernier maître de l'air. Votre but est de maximiser vos récoltes. \n\nLe jeu se déroulera sur 15 tours.\n\nPour chaques tour vous aurez droit a 5 actions maximum. Une fois ces 5 actions ou moins réalisés, une semaine se déroulera et vous pourrez réalisé le prochain tour\nLa réussite de votre partie dépendra de votre capacité à gérer votre potager tout en vous adaptant aux différentes variables extérieurs comme la météo ou les maladies ! \n\nBon courage !.\nTapez sur n'importe quelle touche quand vous avez fini";
        Console.WriteLine(phrase);
        Console.ReadLine();
    }

    public void ChoisirAfficherRegles()
    {
        Console.WriteLine("Voulez vous affichez les règles du jeu : pour oui taper 1, sinon taper 2");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 && result > 2))
        {
            Console.WriteLine("1 oui, 2 non");
        }
        if (result == 1)
        {
            AfficherRegles();
            Console.Clear();
        }
        else { Console.WriteLine("Très bien, le jeu peut donc commencer ! "); }
    }

    public int ChoisirNation()
    {
        Console.WriteLine("A quelle nation appartenait vous ? \n1 (Feu)\n2 (Eau) \n3 (Terre)");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 && result > 3))
        {
            Console.WriteLine("\n1 (Feu)\n2 (Eau) \n3 (Terre)");
        }
        return result;
    }

    public void Jouer()
    {
        ChoisirAfficherRegles();                    // affichage ou non des règles
        Nation = ChoisirNation();                   // permet de choisir la nation
        Meteo m = CreerMeteo(Nation);               //Création de la météo en fonction de la nation
        Potager potager = new Potager(m);           //Creation du potager
                                                    //Création de l'inventaire
        Console.Clear();
        Console.WriteLine("Voici votre potager vide !");
        potager.AfficherPotager();                  //Affichage du premier Terrain

        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"----------SEMAINE NUMERO {Semaine}----------------");
            System.Threading.Thread.Sleep(1000);

            if (rnd.Next(10) == 0) // une chance sur 10 pour le mode urgence
            {
                potager.JouerModeUrgence();
            }
            JouerTour(potager);
            Semaine++;
        }

    }
    public void JouerTour(Potager p) // va jouer les tours du Potager
    {
        // On applique les changements sur la Plante
        // On affiche l'état de toute les plantes
        // On commence par changer la météo
        // Ensuite on applique les changements de la météo au terrain
        p.AfficherPotager();
    }

    public Meteo CreerMeteo(int nation)
    {
        if (nation == 1)
        {
            return new MeteoNationFeu();
        }
        else if (nation == 2)
        {
            return new MeteoNationTerre();
        }
        else
        {
            return new MeteoTribuEau();
        }
    }



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
}
