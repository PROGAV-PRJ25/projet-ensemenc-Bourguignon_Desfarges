public class PlanteTulipe : Plante
{
    public PlanteTulipe() : base("tulipe")
    {}
    // public PlanteTulipe(Terrain terrain) : base("Tulipe", "Vivace", terrain, "Automne", 40, 90, 18, 2, 10,
    //                                             new Maladies("Rouille", 0.2, "taches rouges"),
    //                                             esperanceVie: 8, etatSante: 10, nbRecoltesMax: 3, typePlantes: "Ornementale")
    // {
    // }

    // protected override int GetModificateurTerrain()
    // {
    //     return TerrainActuel switch
    //     {
    //         TerrainArgile _ => +1,
    //         TerrainTerre _ => 0,
    //         TerrainSable _ => -1,
    //         _ => 0
    //     };
    // }

    // public override void Recolter()
    // {
    //     if (EtatSante <= 0) Console.WriteLine("Tulipe morte, impossible de récolter.");
    //     else if (NbRecoltesMax > 0)
    //     {
    //         NbRecoltesMax--;
    //         Console.WriteLine($"Tulipe cueillie. Restant : {NbRecoltesMax}.");
    //     }
    //     else Console.WriteLine("Plus de tulipes à cueillir.");
    // }

    public override string GetIcone()
    {
        return "🌷";
    }
}
