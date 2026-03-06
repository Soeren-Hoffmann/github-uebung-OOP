using System;


public class Spielwelt
{
    private const int _size_x = 25;
    private const int _size_y = 25;
    public Spielfigur?[,] board = new Spielfigur[_size_x, _size_y];
    private static Spielwelt? _instance;

    private static SpielfeldRenderer _renderer = new SpielfeldRenderer();

    private Spielwelt()
    {
    }

    public static Spielwelt GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Spielwelt();
        }
        return _instance;
    }

    public void SpawnPlayer(Spielfigur figur)
    {
        int x_pos;
        int y_pos;
        do
        {
        Random rand = new Random();
        x_pos = rand.Next(_size_x);
        y_pos = rand.Next(_size_y);
        } 
        while(Besetzt(x_pos, y_pos) || IsOutOfBounds(x_pos, y_pos));

        figur.Position = [x_pos, y_pos];
        board[x_pos, y_pos] = figur;
    }

    public bool Besetzt(int x_pos, int y_pos)
    {
        // der out of bounds check, kein möglicher zug (fehlermeldung ausgeben)
        if(IsOutOfBounds(x_pos, y_pos))
        {
            return true;
        }

        if (board[x_pos, y_pos] != null)
        {
            return true;
        }
        return false;

    }

    public void SpielerBewegen(Spielfigur figur, int x_pos, int y_pos)
    {
        // der out of bounds check, kein möglicher zug (fehlermeldung ausgeben)
        if(IsOutOfBounds(x_pos, y_pos))
        {
            return ;
        }

        // Fehler spieler nicht auf dem Feld
        if (figur.Position == null) {
            return;
        }

        Entferne(figur);
        board[x_pos, y_pos] = figur;
        
    }

    public void Entferne(Spielfigur figur)
    {
         // Fehler spieler nicht auf dem Feld
        if (figur.Position == null) {
            return;
        }
        board[figur.Position[0], figur.Position[1]] = null;
    }

    public void VerursacheSchaden(Spielfigur figur)
    {
        if (figur.Position == null) return;

        int Reichweite = figur.Waffe.Reichweite;
        int x = figur.Position[0];
        int y = figur.Position[1];

        for (int dx = -Reichweite; dx <= Reichweite; dx++)
        {
            for (int dy = -Reichweite; dy <= Reichweite; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                if (IsOutOfBounds(x + dx, y + dy)) continue;

                Spielfigur? ziel = board[x + dx, y + dy];
                if (ziel != null)
                {
                    ziel.SchadenNehmen(figur);
                }
            }
        }
    }

    public bool IsOutOfBounds(int x_pos, int y_pos)
    {
        if(x_pos >= _size_x || y_pos >= _size_y || x_pos < 0 || y_pos < 0)
        {
            return true;
        }
        return false;
    }

    public string GetSpielfeld()
    {
        return _renderer.GetSpielfeld(this);
    }
}
