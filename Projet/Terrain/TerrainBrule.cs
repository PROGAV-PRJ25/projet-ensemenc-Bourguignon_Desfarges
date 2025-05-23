public class TerrainBrule : Terrain // bloqueur de terrain
{
    public TerrainBrule(Meteo m) : base("brulé",0,0,m)
    {
        
    }

    public override void PreparerNouveauTerrain() // il ne se passe rien
    {
    }

    public override void PerteDuePlanteTour()
    {
    }

    public override void PerteHumiditeTour()
    {
    }  
}