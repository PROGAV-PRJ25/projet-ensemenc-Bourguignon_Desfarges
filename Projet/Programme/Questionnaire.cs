public class Questionnaire
{
    Random rnd = new Random();

    private List<Question> questions = new List<Question>
    {
        new Question { Numero = 1, Enonce = "Qui est l’Avatar dans la série ?", Choix = new[] { "Zuko", "Katara", "Aang", "Sokka" }, IndexBonneReponse = 2 },
        new Question { Numero = 2, Enonce = "Quel animal accompagne Aang dans tous ses voyages ?", Choix = new[] { "Un ours", "Un bison volant", "Un chien-dragon", "Une tortue-lion" }, IndexBonneReponse = 1 },
        new Question { Numero = 3, Enonce = "Quelle nation est spécialisée dans la maîtrise de l’eau ?", Choix = new[] { "Nation du Feu", "Nomades de l’Air", "Tribus de l’Eau", "Royaume de la Terre" }, IndexBonneReponse = 2 },
        new Question { Numero = 4, Enonce = "Comment s'appelle la sœur de Zuko ?", Choix = new[] { "Azula", "Mai", "Ty Lee", "Yue" }, IndexBonneReponse = 0 },
        new Question { Numero = 5, Enonce = "Qui est le maître de feu de Zuko ?", Choix = new[] { "Iroh", "Ozai", "Aang", "Bumi" }, IndexBonneReponse = 0 },
        new Question { Numero = 6, Enonce = "Quel est le nom du petit lémurien volant d’Aang ?", Choix = new[] { "Appa", "Momo", "Naga", "Bosco" }, IndexBonneReponse = 1 },
        new Question { Numero = 7, Enonce = "Quel personnage est sourd mais redoutable grâce à la maîtrise de la terre ?", Choix = new[] { "Suki", "Ty Lee", "Toph", "Bumi" }, IndexBonneReponse = 2 },
        new Question { Numero = 8, Enonce = "Quelle est la spécialité de Katara ?", Choix = new[] { "Maîtrise du feu", "Maîtrise de l’eau", "Maîtrise de l’air", "Maîtrise de la terre" }, IndexBonneReponse = 1 },
        new Question { Numero = 9, Enonce = "Qui est le père de Zuko ?", Choix = new[] { "Iroh", "Sozin", "Ozai", "Roku" }, IndexBonneReponse = 2 },
        new Question { Numero = 10, Enonce = "Quel est le nom du roi fou du Royaume de la Terre ?", Choix = new[] { "Long Feng", "Bumi", "Kuei", "Piandao" }, IndexBonneReponse = 1 },
        new Question { Numero = 11, Enonce = "Quelle est la relation entre Zuko et Azula ?", Choix = new[] { "Frère et sœur", "Cousins", "Amis d’enfance", "Rivaux politiques" }, IndexBonneReponse = 0 },
        new Question { Numero = 12, Enonce = "Qui est la princesse de la Tribu de l’Eau du Nord ?", Choix = new[] { "Katara", "Yue", "Suki", "Ty Lee" }, IndexBonneReponse = 1 },
        new Question { Numero = 13, Enonce = "Quelle est la technique spéciale que Toph invente ?", Choix = new[] { "Le feu bleu", "Le vol", "La maîtrise du métal", "La foudre" }, IndexBonneReponse = 2 },
        new Question { Numero = 14, Enonce = "Qui dirige la Dai Li à Ba Sing Se ?", Choix = new[] { "Bumi", "Long Feng", "Kuei", "Iroh" }, IndexBonneReponse = 1 },
        new Question { Numero = 15, Enonce = "Quelle est l’origine des pouvoirs de l’Avatar ?", Choix = new[] { "Les dragons", "Le lion-tortue", "L’esprit de la lune", "La planète Sozin" }, IndexBonneReponse = 1 }
    };

    public bool PoserQuestion()
    {
        int index = rnd.Next(questions.Count);
        Question q = questions[index];

        q.Afficher();
        Console.Write("\nVotre réponse (a, b, c, d) : ");
        string reponse = Console.ReadLine()!;

        if (q.Verifier(reponse))
        {
            Console.WriteLine("✅ Bonne réponse !");
            return true;
        }
        else
        {
            Console.WriteLine("❌ Mauvaise réponse.");
            return false;
        }
    }
}
