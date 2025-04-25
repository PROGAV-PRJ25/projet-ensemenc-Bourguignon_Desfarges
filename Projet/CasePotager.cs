public class CasePotager
{
    public Terrain Terrain { get; set; }
    public Plante? Plante { get; set; }

    public CasePotager(Terrain terrain)
    {
        Terrain = terrain;
        Plante = null;
    }
}