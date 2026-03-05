using System.Runtime.CompilerServices;

public class Waffe
{
    public int Schaden { private set; get; }
    public int Reichweite { private set; get; }
    public string Schadensart { private set; get; } = string.Empty;

    public Waffe(int schaden, int reichweite, string schadensart)
    {
        Reichweite = reichweite;
        Schaden = schaden;
        Schadensart = schadensart;
    }
}
