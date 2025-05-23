public class CasePotager
//Case potager représente chaque cases du Potager, elle est relié a un terrain, a une plante ou non et à la météo
{
    public Meteo MeteoPotager { get; set; }
    public Terrain Terrain { get; set; }
    public Plante? Plante { get; set; }

    public CasePotager(Terrain terrain,  Meteo meteo,Plante plante)
    {
        Terrain = terrain;
        Plante = plante;
        MeteoPotager = meteo;
    }

    public CasePotager(Terrain terrain, Meteo meteo)
    {
        Terrain = terrain;
        Plante = null;
        MeteoPotager = meteo;
    }

    public bool EstLibre()
    {
        return Plante == null;
    }

    public string AfficherCase()
    {
        string affichage = "";
        if (Plante == null)
        {
            if (Terrain.TypeSol == "Argile")
            {
                affichage = "🟫";
            }
            else if (Terrain.TypeSol == "Terre")
            {
                affichage = "🟩";
            }
            else if (Terrain.TypeSol == "brulé")
            {
                affichage = "🔥";
            }
            else
            {
                affichage = "⬜";
            }
        }
        else
        {
            affichage = Plante.GetIcone(); // permet de recupérer l'icone qui correspond a la plante
        }
        return affichage;
    }
}