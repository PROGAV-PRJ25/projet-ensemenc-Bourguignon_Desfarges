public class PlanteCactus : Plante
{
    public PlanteCactus(Terrain terrain) 
        : base("Cactus", terrain, 20, 10, 100, 2) // Nom, Terrain, Besoins en eau, Espérance de vie, Santé initiale, Récoltes max
    {
    }

    protected override int GetModificateurTerrain()
    {
        return TerrainActuel switch
        {
            TerrainSable _ => +2,
            TerrainTerre _ => -1,
            TerrainArgile _ => -1,
            _ => 0
        };
    }

    public override void Recolter()
    {
        if (EtatSante <= 0) 
        {
            Console.WriteLine("Cactus mort, impossible de récolter.");
        }
        else if (NbRecoltesMax > 0)
        {
            NbRecoltesMax--;
            Console.WriteLine($"Cactus cueilli. Restant : {NbRecoltesMax}.");
        }
        else 
        {
            Console.WriteLine("Plus de cactus à cueillir.");
        }
    }
}
