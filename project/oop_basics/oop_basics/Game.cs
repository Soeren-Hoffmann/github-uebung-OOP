using System.Security;
using Microsoft.VisualBasic;

public class Game
{
    List<Spielfigur> Players =  new List<Spielfigur>();
    Spielwelt Welt = Spielwelt.GetInstance();

    public void AddSpieler(Spielfigur figur)
    {
        Players.Add(figur);
        Welt.SpawnPlayer(figur);
    }

    public void Start()
    {
        while(true)
        {
            foreach(Spielfigur player in Players)
            {
                Console.Write(Welt.GetSpielfeld());
                if(player.Health <= 0) continue;
                Console.Write(player.Type + " ist am Zug. HP: " + player.Health);

                ConsoleKeyInfo key = Console.ReadKey(false);
                string command = GetMovement(key);

                if(command == Spielfigur.richtung_rechts || command == Spielfigur.richtung_links || command == Spielfigur.richtung_hoch || command == Spielfigur.richtung_runter)
                {
                    player.ZieheAufFeld(command);
                }
                else if(command == Spielfigur.taste_angriff)
                {
                    Welt.VerursacheSchaden(player);
                }
            }
        }
    }

    private string GetMovement(ConsoleKeyInfo key)
    {
        if(key.Key == ConsoleKey.W) return Spielfigur.richtung_hoch;
        else if(key.Key == ConsoleKey.A) return Spielfigur.richtung_links;
        else if(key.Key == ConsoleKey.D) return Spielfigur.richtung_rechts;
        else if(key.Key == ConsoleKey.S) return Spielfigur.richtung_runter;
        else if(key.Key == ConsoleKey.Spacebar) return Spielfigur.taste_angriff;
        return "";
    }
}