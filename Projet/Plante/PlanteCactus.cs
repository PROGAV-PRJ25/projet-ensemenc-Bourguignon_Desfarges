public class PlanteCactus : Plante
{

    public PlanteCactus() : base("cactus",3,12,3,[0,90],[0,50])
    {}

    public override string GetIcone()
    {
        return "🌵";
    }
}
