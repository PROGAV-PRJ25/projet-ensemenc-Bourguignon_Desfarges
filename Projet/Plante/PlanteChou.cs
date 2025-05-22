public class PlanteChou : Plante
{
    public PlanteChou() : base("chou")
    {}
    // public PlanteChou(Terrain terrain) : base("Chou", "Vivace", terrain, "Hiver", 50, 60, 15, 2, 6,
    //                                           new Maladies("Peronospora", 0.1, "taches blanches"),
    //                                           esperanceVie: 9, etatSante: 10, nbRecoltesMax: 4, typePlantes: "Comestible")
    // {
    // }

    // protected override int GetModificateurTerrain()
    // {
    //     return TerrainActuel switch
    //     {
    //         TerrainTerre _ => +2,
    //         TerrainArgile _ => 0,
    //         TerrainSable _ => -1,
    //         _ => 0
    //     };
    // }


    public override string GetIcone()
    {
        return "🥬";
    }
    
}
