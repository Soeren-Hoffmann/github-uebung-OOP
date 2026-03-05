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

                if(command == "rechts" || command == "links" || command == "hoch" || command == "runter")
                {
                    player.ZieheAufFeld(command);
                }
                else if(command == "attack")
                {
                    Welt.VerursacheSchaden(player);
                }
            }
        }
    }

    private string GetMovement(ConsoleKeyInfo key)
    {
        if(key.Key == ConsoleKey.W) return "hoch";
        else if(key.Key == ConsoleKey.A) return "links";
        else if(key.Key == ConsoleKey.D) return "rechts";
        else if(key.Key == ConsoleKey.S) return "runter";
        else if(key.Key == ConsoleKey.Spacebar) return "attack";
        return "";
    }
}