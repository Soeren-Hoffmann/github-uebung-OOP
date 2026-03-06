using System.Security;
using Microsoft.VisualBasic;

public class Game
{
    List<Spielfigur> Players =  new List<Spielfigur>();
    private readonly Spielwelt _Welt; 
    private readonly Kampfsystem _Kampf;

    public Game()
    {
        _Welt = Spielwelt.GetInstance(); 
        _Kampf = new Kampfsystem(_Welt);
    }

    public void AddSpieler(Spielfigur figur)
    {
        Players.Add(figur);
        _Welt.SpawnPlayer(figur);
    }

    public void Start()
    {
        while(true)
        {
            foreach(Spielfigur player in Players)
            {
                Console.Write(_Welt.GetSpielfeld());
                if(player.Health <= 0) continue;
                Console.Write(player.Type + " ist am Zug. HP: " + player.Health);

                ConsoleKeyInfo key = Console.ReadKey(false);
                Spielfigur.Richtung command = GetMovement(key);

                if(command == Spielfigur.Richtung.Rechts || command == Spielfigur.Richtung.Links || command == Spielfigur.Richtung.Hoch || command == Spielfigur.Richtung.Runter)
                {
                    player.ZieheAufFeld(command);
                }
                else if(command == Spielfigur.Richtung.Angriff)
                {
                    _Welt.VerursacheSchaden(player);
                }
            }
        }
    }

    private Spielfigur.Richtung GetMovement(ConsoleKeyInfo key)
    {
        if(key.Key == ConsoleKey.W) return Spielfigur.Richtung.Hoch;
        else if(key.Key == ConsoleKey.A) return Spielfigur.Richtung.Links;
        else if(key.Key == ConsoleKey.D) return Spielfigur.Richtung.Rechts;
        else if(key.Key == ConsoleKey.S) return Spielfigur.Richtung.Runter;
        else if(key.Key == ConsoleKey.Spacebar) return Spielfigur.Richtung.Angriff;
        
        return Spielfigur.Richtung.NONE;
    }
}