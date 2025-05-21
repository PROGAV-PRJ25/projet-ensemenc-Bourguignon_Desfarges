public class CasePotager
//Case potager représente chaque cases du Potager, elle est relié a un terrain, a une plante ou non et à la météo
{
    public Meteo MeteoPotager { get; set; }
    public Terrain Terrain { get; set; }
    public Plante? Plante { get; set; }

    public CasePotager(Terrain terrain, Plante plante, Meteo meteo)
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
}