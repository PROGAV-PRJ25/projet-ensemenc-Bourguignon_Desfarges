public class PlanteTomate : Plante
{
    public PlanteTomate(Terrain terrain) : base("Tomate", "Annuelle", terrain, "Printemps", 60, 80, 22, 1, 7,
                                                new Maladies("Mildiou", 0.3, "taches jaunes"),
                                                esperanceVie: 7, etatSante: 10, nbRecoltesMax: 5, typePlantes: "Comestible")
    {
        if (terrain is TerrainSable)
        {
            Console.WriteLine("Erreur : la tomate ne peut pas pousser sur le sable.");
            EtatSante = 0;
        }
    }

    protected override int GetModificateurTerrain()
    {
        return TerrainActuel switch
        {
            TerrainTerre _ => +1,
            TerrainArgile _ => 0,
            TerrainSable _ => -2,
            _ => 0
        };
    }

    public override void Recolter()
    {
        if (EtatSante <= 0) Console.WriteLine("Tomate morte, impossible de récolter.");
        else if (NbRecoltesMax > 0)
        {
            NbRecoltesMax--;
            Console.WriteLine($"Tomate récoltée. Restant : {NbRecoltesMax}.");
        }
        else Console.WriteLine("Plus de tomates à récolter.");
    }

    public override string GetIcone()
    {
        return "🍅";
    }
}
