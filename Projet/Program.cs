// Jeu j = new Jeu();
// j.Jouer();

 MeteoNationFeu m = new MeteoNationFeu();
// Console.WriteLine("Température de la semaine " + m.Temperature);
// Console.WriteLine("Chance sur 10 qu'ils pleuvent : " + m.Pluie);
// m.AppliquerMeteoTour();
// Console.WriteLine("Nouvelle température " + m.Temperature);
// if (m.IlPleut)
// {
//     Console.WriteLine("Il pleut aujourd'hui");
// }
// else
// {
//     Console.WriteLine("Il ne pleut pas");
// }


// Potager p = new Potager(m);

// p.AfficherPotager();

// p.ChoisirPlanter();

// p.AfficherPotager();

// p.JouerModeUrgence();

// p.AfficherPotager();

// TerrainArgile ter = new TerrainArgile();
// Console.WriteLine(ter.HumiditeSol);

TerrainTerre test = new TerrainTerre();
PlanteCactus p = new PlanteCactus();
CasePotager ca = new CasePotager(test, m, p);
Console.WriteLine(p.Morte);
p.TourPlante();
Console.WriteLine(p.Morte);
Console.WriteLine(p.Age);
Console.WriteLine(p.EtatSante);
p.TourPlante();
Console.WriteLine(p.Morte);
Console.WriteLine(p.Age);
Console.WriteLine(p.EtatSante);
Console.WriteLine(p.Dessechee);
Console.WriteLine(p.BonneTemp);



