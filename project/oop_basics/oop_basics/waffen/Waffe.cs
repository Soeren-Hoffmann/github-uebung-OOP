using System.Runtime.CompilerServices;

public class Waffe
{
    public int Schaden { set; get; }
    public int Reichweite { set; get; }
    public string Schadensart { set; get; } = string.Empty;

    public Waffe(int schaden, int reichweite, string schadensart)
    {
        Reichweite = reichweite;
        Schaden = schaden;
        Schadensart = schadensart;
    }
}
