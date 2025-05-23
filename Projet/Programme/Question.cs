public class Question
{
    public int Numero { get; set; }
    public string Enonce { get; set; }
    public string[] Choix { get; set; }
    public int IndexBonneReponse { get; set; }

    public void Afficher()
    {
        Console.WriteLine($"\nQuestion {Numero}: {Enonce}");
        for (int i = 0; i < Choix.Length; i++)
        {
            Console.WriteLine($"{(char)('a' + i)}) {Choix[i]}");
        }
    }

    public bool Verifier(string reponse)
    {
        int indexReponse = reponse.ToLower()[0] - 'a';
        return indexReponse == IndexBonneReponse;
    }
}