public class PlanteCactus : Plante
{

    public PlanteCactus() : base("cactus")
    {}
    // public PlanteCactus(Terrain terrain) : base("Cactus", "Vivace", terrain, "Printemps", 20, 100, 25, 1, 12,
    //                                            new Maladies("Acariens", 0.15, "points noirs"),
    //                                            esperanceVie: 10, etatSante: 10, nbRecoltesMax: 2, typePlantes: "Ornementale")
    // {
    // }

    // protected override int GetModificateurTerrain()
    // {
    //     return TerrainActuel switch
    //     {
    //         TerrainSable _ => +2,
    //         TerrainTerre _ => -1,
    //         TerrainArgile _ => -1,
    //         _ => 0
    //     };
    // }

    public override string GetIcone()
    {
        return "🌵";
    }
}
