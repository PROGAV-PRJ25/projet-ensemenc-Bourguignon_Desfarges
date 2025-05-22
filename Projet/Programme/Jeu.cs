public class Jeu
{
    public int Semaine { get; set; } // repaire temporelle 

    public Jeu()
    {
        Semaine = 1;
    }
    public void AfficherRegles()
    {
        string phrase = "";
        phrase += "Ce jeu est un simulateur de potager dans l'univers d'Avatar le Dernier maître de l'air. Votre but est de maximiser vos récoltes. \nLe jeu se déroulera sur 15 tours.\nPour chaques tour vous aurez droit a 5 actions maximum. Une fois ces 4 actions ou moins réalisés, une semaine se déroulera et vous pourrez réalisé le prochain tour\nLa réussite de votre partie dépendra de votre capacité à gérer votre potager tout en vous adaptant aux différentes variables extérieurs comme la météo ou les maladies ! \n Bon courage !.";
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
        ChoisirAfficherRegles(); // affichage ou non des règles
        ChoisirNation(); // permet de choisir la nation
                         //Création de la météo en fonction de la nation
                         //Creation du potager
                         //Création de l'inventaire
                         //Affichage du premier Terrain
                         // choix joueur


        //JouerTour() 

    }
    public void JouerTour() // va jouer les tours du Potager
    {
        // On applique les changements sur la Plante
        // On affiche l'état de toute les plantes
        // On commence par changer la météo
        // Ensuite on applique les changements de la météo au terrain
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
