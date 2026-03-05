internal class Program
{
    private static void Main(string[] args)
    {
        Game Game = new Game();
        Spielfigur spieler = new Spielfigur("X", 100, 1, new Schwert(20), 10, 10);
        Spielfigur spieler2 = new Spielfigur("Y", 100, 1, new Keule(10), 10, 10);
        
        Game.AddSpieler(spieler);
        Game.AddSpieler(spieler2);
        Game.Start();
    }
}