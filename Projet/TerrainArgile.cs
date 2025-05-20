public class TerrainArgile : Terrain
{
    Random rnd = new Random();
    // un terrain argileux est un terrain riche en eau, son taux d'humidité est  de 50%
    // un terrain argileux est riche en minéraux
    public TerrainArgile(double ensoleillement, double temperature)
        : base("Argile", 50, 80, ensoleillement, temperature)
    {
    }

    //Constructeur basique pour pouvoir modifier facilement les composantes
    public TerrainArgile(double humiditeSol, double qualiteSol, double ensoleillement, double temperature)
        : base("Argile", humiditeSol, qualiteSol, ensoleillement, temperature)
    {
    }


}
