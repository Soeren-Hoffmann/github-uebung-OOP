using System;

public class Spielwelt
{
    public int Size_x
    {
        get
        {
            return _size_x;
        }
    }

    public int Size_y
    {
        get
        {
            return _size_y;
        }
    }
    private const int _size_x = 25;
    private const int _size_y = 25;
    public Spielfigur[,] board = Spielfigur[_size_x, _size_y];

    private static Spielwelt? _instance;

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

    public void SpawnPlayer(Spielfiegur Figur, int x_pos, int y_pos)
    {
        if (!besetzt(x_pos, y_pos))
        {
            board[x_pos, y_pos] = Figur;
        }

    }

    public bool besetzt(int x_pos, int y_pos)
    {
        if (board[x_pos, y_pos] != null)
        {
            return true;
        }
        return false;

    }
}
