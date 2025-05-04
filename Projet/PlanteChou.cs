public class PlanteChou : Plante
{
    public PlanteChou(Terrain terrain) : base("Chou", "Vivace", terrain, "Hiver", 50, 60, 15, 2, 6,
                                              new Maladies("Peronospora", 0.1, "taches blanches"),
                                              esperanceVie: 9, etatSante: 10, nbRecoltesMax: 4, typePlantes: "Comestible")
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
