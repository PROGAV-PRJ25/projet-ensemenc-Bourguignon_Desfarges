public class PlanteChou : Plante
{
    public PlanteChou(Terrain terrain) : base("Chou", terrain, 50, esperanceVie: 9, etatSante: 10, nbRecoltesMax: 4)
    {
    }

    protected override int GetModificateurTerrain()
    {
        return TerrainActuel switch
        {
            TerrainTerre _ => +2,
            TerrainArgile _ => 0,
            TerrainSable _ => -1,
            _ => 0
        };
    }

    public override void Recolter()
    {
        if (EtatSante <= 0) Console.WriteLine("Chou mort, impossible de récolter.");
        else if (NbRecoltesMax > 0)
        {
            NbRecoltesMax--;
            Console.WriteLine($"Chou récolté. Restant : {NbRecoltesMax}.");
        }
        else Console.WriteLine("Plus de choux à récolter.");
    }
}
