public class CasePotager
{
    public Terrain Terrain { get; set; }
    public Plante Plante { get; set; }

    public CasePotager(Terrain terrain, Plante plante = null)
    {
        Terrain = terrain;
        Plante = plante;
    }

    public bool EstLibre()
    {
        return Plante == null;
    }
}