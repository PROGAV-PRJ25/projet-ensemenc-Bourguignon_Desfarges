public class Potager
{
    public Meteo Meteo;
    public int PotagerLongueur { get; private set; }
    public int PotagerLargeur { get; private set; }
    protected CasePotager[,] GrillePotager { get; set; }

    public Potager(Meteo meteo)
    {
        Meteo = meteo;
        PotagerLongueur = RecupererTaillePotager(true);
        PotagerLargeur = RecupererTaillePotager(false);
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

    public CasePotager[,] CreationPotager()
    {
        CasePotager[,] grillePotager = new CasePotager[PotagerLongueur, PotagerLargeur];
        
    }
}