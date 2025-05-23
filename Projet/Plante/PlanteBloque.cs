public class PlanteBloque : Plante
{
    public PlanteBloque() : base("Brulé",99,15,0,[-10,100],[-10,100])
    {

    }

    public override string GetIcone()
    {
        return "❌";
    }
}