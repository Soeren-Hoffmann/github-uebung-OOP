public class Kampfsystem
{
    private Spielwelt Welt;

    public Kampfsystem(Spielwelt welt)
    {
        Welt = welt;
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
                if (Welt.IsOutOfBounds(x + dx, y + dy)) continue;

                Spielfigur? ziel = Welt.board[x + dx, y + dy];
                if (ziel != null)
                {
                    ziel.SchadenNehmen(figur);
                }
            }
        }
    }
}